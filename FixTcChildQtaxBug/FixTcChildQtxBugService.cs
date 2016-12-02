using MongoDB.Bson.Serialization;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FixTcChildQtaxBug
{
	public class FixTcChildQtxBugService
	{
		private FixTcChildQtxBugRepository _repo;
		private MongodbHelper _mongoHelper;
		private Logger _logger;
		private const string MONGO_ISSUE_COLLECTION_NAME = "Log_Issue_Ticket";
		private List<string> childEtitList = new List<string>() { "CHR", "CHS", "CHD", "INF", "C" };

		public FixTcChildQtxBugService(MongodbHelper mongoHelper, FixTcChildQtxBugRepository repo, Logger logger)
		{
			this._repo = repo;
			this._mongoHelper = mongoHelper;
			this._logger = logger;
		}

		public void FixBugs()
		{
			bool result = true;
			var bugList = _repo.getBugsList();
			if (bugList != null && bugList.Any())
			{
				RegisterClassTypeInBson();

				foreach (var bug in bugList)
				{
					try
					{
						var t = Task.Run(() => getMongoLog(bug));
						result = result & t.Result;
					}
					catch (Exception)
					{

					}
				}
			}
			
			//return true;
		}

		private async Task<bool> getMongoLog(FixTcChildQtxBugModel bug)
		{
			try
			{
				_logger.Debug(string.Format("訂單: {0} - {1}", bug.ordr_year, bug.ordr_ordr));
				//var taskLogList = AsyncHelpers.RunSync<List<IssueTktLog>>(() => this._mongoHelper.queryAsync<IssueTktLog>(MONGO_ISSUE_COLLECTION_NAME, x => x.wtYear == bug.Wor00_wtyear && x.wtordr == bug.Wor00_wtordr));
				var taskLogList = await this._mongoHelper.queryAsync<IssueTktLog>(MONGO_ISSUE_COLLECTION_NAME, x => x.wtYear == bug.Wor00_wtyear && x.wtordr == bug.Wor00_wtordr);
				if (taskLogList != null && taskLogList.Any())
				{
					var log = taskLogList.LastOrDefault();

					if (log != null)
					{
						IssueTktEvent gdsIssueResp = log.Step.Find(x => x.message == "GDS IssueTicket response");
						resultModel<IssueTicketResult> resp = (resultModel<IssueTicketResult>)gdsIssueResp.content;

						if (resp != null && resp.errorCode == 0)
						{
							if (resp.result.tstkm00s.Exists(x => x.tick_curr != "NTD")) { _logger.Info(string.Format("[非台幣: {0} - {1}]", bug.ordr_year, bug.ordr_ordr)); return true; }
							if (resp.result.Tax_c <= 0) { _logger.Info(string.Format("[稅金金額小於等於0: {0} - {1}]", bug.ordr_year, bug.ordr_ordr)); return true; }

							//找到小孩子的tstkm00
							var childTickets = resp.result.tstkm00s.FindAll(x => childEtitList.Exists(y => y.Trim().ToUpper() == x.tick_etit.Trim().ToUpper()));
							int newQtax = resp.result.Tax_c;
							if (newQtax == childTickets.FirstOrDefault().tick_qtax) { _logger.Info(string.Format("[稅金沒變: {0} - {1}]", bug.ordr_year, bug.ordr_ordr)); return true; }

							_logger.Info(string.Format("準備處理: {0} - {1}", bug.ordr_year, bug.ordr_ordr));

							int gap = resp.result.Tax_a - resp.result.Tax_c;
							double erat = _repo. getErat(childTickets.FirstOrDefault());
							childTickets.ForEach(tTstkm00 =>
							{
								_logger.Info(string.Format("稅金變化: {0} -> {1}", tTstkm00.tick_qtax, newQtax));

								tTstkm00.tick_qtax = tTstkm00.tick_qtax - gap;
								tTstkm00.tick_cost = tTstkm00.tick_cost - gap;
								tTstkm00.tick_tot_amt = tTstkm00.tick_tot_amt - gap;
							});

							_logger.Info(string.Format("匯率: {0}", erat));

							resp.result.tstkm00s.ForEach(tTstkm00 => tTstkm00.tick_erat = erat);

							double ordr_tot_amt = resp.result.tstkm00s.Sum(m => m.tick_tot_amt);
							double ordr_cost = resp.result.tstkm00s.Sum(m => m.tick_tot_cost());

							//更新tstkm00
							//更新ssorm00(TC單總額)
							_repo.UpdateFixTcChildQtxBugData(bug.ordr_year, bug.ordr_ordr, ordr_cost, ordr_tot_amt, childTickets);

							return true;
						}
						else
						{
							 _logger.Info(string.Format("[API開票失敗: {0} - {1}]", bug.ordr_year, bug.ordr_ordr));
							return true;
						}
					}
					else
					{
						_logger.Info(string.Format("[不是走API開票: {0} - {1}]", bug.ordr_year, bug.ordr_ordr));
						return true;
					}
				}
				else
				{
					_logger.Info(string.Format("[不是走API開票: {0} - {1}]", bug.ordr_year, bug.ordr_ordr));
					return true;
				}
			}
			catch (Exception ex)
			{
				_logger.Warn(ex, string.Format("[發生錯誤: {0} - {1}]", bug.ordr_year, bug.ordr_ordr));
				return false;
			}
			finally
			{
				_logger.Info("---------------------------------------------------------");
			}

			return false;
			
		}

		private void RegisterClassTypeInBson()
		{
			if (!BsonClassMap.IsClassMapRegistered(typeof(IssueTktLog)))
			{
				BsonClassMap.RegisterClassMap<IssueTktLog>();
			}

			if (!BsonClassMap.IsClassMapRegistered(typeof(IssueTktMatchineParam)))
			{
				BsonClassMap.RegisterClassMap<IssueTktMatchineParam>();
			}

			if (!BsonClassMap.IsClassMapRegistered(typeof(resultModel<IssueTicketResult>)))
			{
				BsonClassMap.RegisterClassMap<resultModel<IssueTicketResult>>();
			}

			if (!BsonClassMap.IsClassMapRegistered(typeof(setTranOrderViewModel)))
			{
				BsonClassMap.RegisterClassMap<setTranOrderViewModel>();
			}
			if (!BsonClassMap.IsClassMapRegistered(typeof(setTcOrderViewModel)))
			{
				BsonClassMap.RegisterClassMap<setTcOrderViewModel>();
			}

			if (!BsonClassMap.IsClassMapRegistered(typeof(SetCmdPara)))
			{
				BsonClassMap.RegisterClassMap<SetCmdPara>();
			}
			
		}

	}

	public static class AsyncHelpers
	{
		/// <summary>
		/// Execute's an async Task<T> method which has a void return value synchronously
		/// </summary>
		/// <param name="task">Task<T> method to execute</param>
		public static void RunSync(Func<Task> task)
		{
			var oldContext = SynchronizationContext.Current;
			var synch = new ExclusiveSynchronizationContext();
			SynchronizationContext.SetSynchronizationContext(synch);
			synch.Post(async _ =>
			{
				try
				{
					await task();
				}
				catch (Exception e)
				{
					synch.InnerException = e;
					throw;
				}
				finally
				{
					synch.EndMessageLoop();
				}
			}, null);
			synch.BeginMessageLoop();

			SynchronizationContext.SetSynchronizationContext(oldContext);
		}

		/// <summary>
		/// Execute's an async Task<T> method which has a T return type synchronously
		/// </summary>
		/// <typeparam name="T">Return Type</typeparam>
		/// <param name="task">Task<T> method to execute</param>
		/// <returns></returns>
		public static T RunSync<T>(Func<Task<T>> task)
		{
			var oldContext = SynchronizationContext.Current;
			var synch = new ExclusiveSynchronizationContext();
			SynchronizationContext.SetSynchronizationContext(synch);
			T ret = default(T);
			synch.Post(async _ =>
			{
				try
				{
					ret = await task();
				}
				catch (Exception e)
				{
					synch.InnerException = e;
					throw;
				}
				finally
				{
					synch.EndMessageLoop();
				}
			}, null);
			synch.BeginMessageLoop();
			SynchronizationContext.SetSynchronizationContext(oldContext);
			return ret;
		}

		private class ExclusiveSynchronizationContext : SynchronizationContext
		{
			private bool done;
			public Exception InnerException { get; set; }
			readonly AutoResetEvent workItemsWaiting = new AutoResetEvent(false);
			readonly Queue<Tuple<SendOrPostCallback, object>> items =
				new Queue<Tuple<SendOrPostCallback, object>>();

			public override void Send(SendOrPostCallback d, object state)
			{
				throw new NotSupportedException("We cannot send to our same thread");
			}

			public override void Post(SendOrPostCallback d, object state)
			{
				lock (items)
				{
					items.Enqueue(Tuple.Create(d, state));
				}
				workItemsWaiting.Set();
			}

			public void EndMessageLoop()
			{
				Post(_ => done = true, null);
			}

			public void BeginMessageLoop()
			{
				while (!done)
				{
					Tuple<SendOrPostCallback, object> task = null;
					lock (items)
					{
						if (items.Count > 0)
						{
							task = items.Dequeue();
						}
					}
					if (task != null)
					{
						task.Item1(task.Item2);
						if (InnerException != null) // the method threw an exeption
						{
							throw new AggregateException("AsyncHelpers.Run method threw an exception.", InnerException);
						}
					}
					else
					{
						workItemsWaiting.WaitOne();
					}
				}
			}

			public override SynchronizationContext CreateCopy()
			{
				return this;
			}
		}
	}
}
