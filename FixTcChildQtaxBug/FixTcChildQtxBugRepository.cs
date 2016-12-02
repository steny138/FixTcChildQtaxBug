using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NLog;

namespace FixTcChildQtaxBug
{
	public class FixTcChildQtxBugRepository
	{
		private string _connectString ;
		private Logger _logger;
		public FixTcChildQtxBugRepository(string connectString ,Logger logger)
		{
			this._connectString = connectString;
			this._logger = logger;
		}

		public bool UpdateFixTcChildQtxBugData(string year, string ordr, double ordr_cost, double ordr_tot_amt, List<Tstkm00> paramters)
		{
			bool result = true;
			using (var conn = SQLFunc.OpenConnection(this._connectString))
			{
				using (var trans = conn.BeginTransaction())
				{
					try
					{
						foreach (var paramter in paramters)
						{
							result = result && UpdateTstkm00(paramter, conn, trans);
						}

						result = result && UpdateSSorm00(year, ordr, ordr_cost, ordr_tot_amt, conn, trans);

						trans.Commit();
					}
					catch (SqlException sex)
					{
						trans.Rollback();
					}
				}
			}
			return result;
		}
		
		public bool UpdateTstkm00(Tstkm00 paramter ,SqlConnection conn, SqlTransaction tran)
		{

			#region 參數
			string sqlExecute = string.Empty;
			DynamicParameters sqlParam = new DynamicParameters();
			sqlParam.Add("@tick_qtax",paramter.tick_qtax);
			sqlParam.Add("@tick_cost",paramter.tick_cost);
			sqlParam.Add("@tick_tot_amt", paramter.tick_tot_amt);
			sqlParam.Add("@tick_tot_cost", paramter.tick_tot_cost());
			sqlParam.Add("@tick_tkno", paramter.tick_tkno);
			sqlParam.Add("@tick_tkseq", paramter.tick_tkseq);
			#endregion

			#region SQL 語法
			sqlExecute = @"
                  UPDATE TSTKM00 SET tick_qtax = @tick_qtax, tick_cost = @tick_cost, tick_tot_amt = @tick_tot_amt, tick_tot_cost = @tick_tot_cost
					WHERE tick_tkno = @tick_tkno AND tick_tkseq = @tick_tkseq ;";
			#endregion

			#region SQL 查詢
			
			return conn.Execute(sqlExecute, sqlParam, tran) > 0;
			
			#endregion
		}

		public bool UpdateSSorm00(string year,string ordr,double ordr_cost, double ordr_tot_amt, SqlConnection conn, SqlTransaction tran)
		{

			#region 參數
			string sqlExecute = string.Empty;
			DynamicParameters sqlParam = new DynamicParameters();
			sqlParam.Add("@ordr_tot_amt", ordr_tot_amt);
			sqlParam.Add("@ordr_cost", ordr_cost);
			sqlParam.Add("@ordr_year", year);
			sqlParam.Add("@ordr_ordr", ordr);
			#endregion

			#region SQL 語法
			sqlExecute = @"
                  UPDATE SSORM00 SET ordr_tot_amt = @ordr_tot_amt, ordr_cost = @ordr_cost
					WHERE ordr_year = @ordr_year AND ordr_ordr = @ordr_ordr ;";
			#endregion

			#region SQL 查詢

			return conn.Execute(sqlExecute, sqlParam, tran) > 0;

			#endregion
		}

		public double getErat(Tstkm00 paramter)
		{
			#region SQL 語法
			string sqlQuery = @"
					select tick_erat from tstkm00 WHERE tick_tkno = @tick_tkno AND tick_tkseq = @tick_tkseq ;";
			#endregion

			DynamicParameters sqlParam = new DynamicParameters();
			sqlParam.Add("@tick_tkno", paramter.tick_tkno);
			sqlParam.Add("@tick_tkseq", paramter.tick_tkseq);

			#region SQL 查詢
			using (SqlConnection conn = SQLFunc.OpenConnection(_connectString))
			{
				return conn.Query<double>(sqlQuery, sqlParam).FirstOrDefault();
			}
			#endregion
		}

		public IEnumerable<FixTcChildQtxBugModel> getBugsList()
		{
			
			#region SQL 語法
			string sqlQuery = @"
					SELECT
						*
					FROM (SELECT
							(SELECT
									MAX(tick_qtax)
								FROM tstkm00
								WHERE tick_year = ordr_year
								AND tick_ordr = ordr_ordr
								AND tick_etit IN ('CHR', 'CHS', 'CHD', 'INF', 'C')
								AND ordr_prof = tick_prof)
							AS x
							,(SELECT
									MAX(tick_qtax)
								FROM tstkm00
								WHERE tick_year = ordr_year
								AND tick_ordr = ordr_ordr
								AND tick_etit NOT IN ('CHR', 'CHS', 'CHD', 'INF', 'C')
								AND ordr_prof = tick_prof)
							AS y
							,ordr_year,ordr_ordr, s02.or02_wtyear, s02.or02_wtordr,Wor00_year,Wor00_ordr,Wor00_wtyear,Wor00_wtordr,ordr_date
						FROM ssorm00
						JOIN ssorm02 s02 ON s02.or02_wtyear = ordr_year and s02.or02_wtordr = ordr_ordr
						JOIN wtorm00 ON Wor00_year = s02.or02_year and Wor00_ordr = s02.or02_ordr 
						WHERE ordr_year = '2016'
						AND ordr_tkorder = '1'
						--AND ordr_cost = 0
						AND ordr_date >= '2016-11-22'
						AND ordr_acclock2 = 0
						AND ordr_sts = 0
						AND (SELECT
								SUM(tick_cost * tick_erat)
							FROM tstkm00
							WHERE tick_year = ordr_year
							AND tick_ordr = ordr_ordr
							AND tick_etit IN ('CHR', 'CHS', 'CHD', 'INF', 'C')
							AND ordr_prof = tick_prof)
						> 0) AS data
					WHERE x = y and x > 0
					ORDER BY ordr_date
				";
			#endregion

			DynamicParameters sqlParam = new DynamicParameters();

			#region SQL 查詢
			using (SqlConnection conn = SQLFunc.OpenConnection(_connectString))
			{
				return conn.Query<FixTcChildQtxBugModel>(sqlQuery, sqlParam);
			}
			#endregion
		}

	}

	public sealed class SQLFunc
	{
		/// <summary>指定包含連接字串的字串時，初始化 System.Data.SqlClient.SqlConnection 類別的新執行個體，並開啟資料庫連接。</summary>
		/// <param name="connectionString">用來開啟 SQL Server 資料庫的連接。</param>
		/// <returns></returns>
		public static SqlConnection OpenConnection(string connectionString)
		{
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();
			return connection;
		}

		#region 開始交易 StartTransaction

		/// <summary>開始交易</summary>
		/// <param name="connStr"></param>
		/// <param name="tran"></param>
		/// <returns></returns>
		public static int StartTransaction(string connStr, Func<SqlTransaction, int> tran)
		{
			int result = 0;
			using (SqlConnection conn = OpenConnection(connStr))
			using (SqlTransaction transaction = conn.BeginTransaction())
			{
				try
				{
					result = tran.Invoke(transaction);
				}
				catch (Exception e)
				{
					result = -1;
					transaction.Rollback();
					throw e;
				}
				if (result > 0)
				{
					transaction.Commit();
				}
				else
				{
					transaction.Rollback();

				}
			}
			return result;
		}

		#endregion
	}
}
