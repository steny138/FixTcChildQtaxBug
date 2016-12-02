using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixTcChildQtaxBug
{
	class Program
	{
		private static Logger _logger = LogManager.GetCurrentClassLogger();


		static void Main(string[] args)
		{
			string mongoConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MongoTkt"].ConnectionString;
			string erpConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ERP"].ConnectionString;
			//Logger logger = NLog.LogManager.GetCurrentClassLogger();
			var mongohelper = MongodbHelper.CreateConnction(mongoConnString);
			var fix = new FixTcChildQtxBugRepository(erpConnString, _logger);

			FixTcChildQtxBugService service = new FixTcChildQtxBugService(mongohelper, fix, _logger);

			service.FixBugs();

			Console.WriteLine("finished");
			Console.ReadKey();
		}	
	}
}
