using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FixTcChildQtaxBug
{
	public class FixTcChildQtxBugModel
	{
		public string ordr_year { get; set; }
		public string ordr_ordr { get; set; }
		public string or02_wtyear { get; set; }
		public int or02_wtordr { get; set; }
		public string Wor00_year { get; set; }
		public int Wor00_ordr { get; set; }
		public string Wor00_wtyear { get; set; }
		public string Wor00_wtordr { get; set; }
		public DateTime ordr_date { get; set; }
	}
	public class IssueTktLog : MongodbDocument
	{
		public DateTime timestamp { get; set; }
		public string wtYear { get; set; }
		public string wtordr { get; set; }

		public string errorCode { get; set; }
		public string errorMessage { get; set; }
		public List<IssueTktEvent> Step { get; set; }
		public issueTktViewModel Request { get; set; }
		public result<string> Response { get; set; }

		public IssueTktLog()
		{
			this.timestamp = DateTime.Now;
		}
	}
	public class result<T>
	{
		public bool IsSuccess { get; set; }
		public string Msg { get; set; }
		public T Data { get; set; }
		public result()
		{
			IsSuccess = false;
			Msg = string.Empty;
		}
	}
	public class IssueTktEvent
	{
		public DateTime timestamp { get; set; }
		public string flow { get; set; }
		public string pnr { get; set; }
		public string message { get; set; }
		public object content { get; set; }
		public IssueTktEvent()
		{
			this.timestamp = DateTime.Now;
		}

		public static IssueTktEvent create(string flow, string message, string pnr, object content)
		{
			return new IssueTktEvent()
			{
				flow = flow,
				message = message,
				pnr = pnr,
				content = content
			};
		}
	}
	public class issueTktViewModel
	{
		public string wtYear { get; set; }
		public string wtOrdr { get; set; }
		public string isETicket { get; set; }
		public string webmember { get; set; }
		public string webCode { get; set; }

		public string isERP { get; set; }
		public string webCurr { get; set; }
	}
	public class resultModel<T>
	{
		public int errorCode { get; set; }
		public string errorDesc { get; set; }
		public T result { get; set; }
		public resultModel()
		{
			errorCode = 0;
			errorDesc = string.Empty;
		}
	}
	public class IssueTicketResult
	{
		public List<LogTstkm50> logTstkm50s { get; set; }
		public List<Tstkm00> tstkm00s { get; set; }
		public int Net_a { get; set; }
		public int Net_c { get; set; }
		public int Tax_a { get; set; }
		public int Tax_c { get; set; }
		public int QTax { get; set; }
		public int pr00_tc_amt1 { get; set; }
		public int pr00_tc_amt2 { get; set; }
		public IssueTicketResult()
		{
			logTstkm50s = new List<LogTstkm50>();
			tstkm00s = new List<Tstkm00>();
			Net_a = 0;
			Net_c = 0;
			QTax = 0;
			Tax_a = 0;
			Tax_c = 0;
			pr00_tc_amt1 = 0;
			pr00_tc_amt2 = 0;
		}

	}
	public class SetCmdPara
	{
		public string pcc { get; set; }
		public string crs { get; set; }
		public List<string> myResult { get; set; }
	}
	public class IssueTktMatchineParam
	{
		public string prcno { get; set; }
		public string prodno { get; set; }

		public string crs { get; set; }
		public string pcc { get; set; }
		public string pnr { get; set; }

		public string wtyear { get; set; }
		public string wtordr { get; set; }

		public string curr { get; set; }
		public string webcurr { get; set; }
		public string webmember { get; set; }
		public string agent { get; set; }
		public string issueProf { get; set; }

		public bool isErp { get; set; }


		public wtorm00 order { get; set; }
		public List<wtorm10> passengers { get; set; }
		public List<wtorm20> segments { get; set; }
		public Tkpcm00 pccSetting { get; set; }
		public List<Tkpcm00> pccSettings { get; set; }
		public IssueTicketRQ ticketIssueParam { get; set; }

		public BfmPricedItinerary.PricedItineraryType priceItin { get; set; }
	}
	public class wtorm00
	{
		/// <summary>網位單年碼</summary>
		public string vWor00_wtyear;
		/// <summary>網位單號</summary>
		public string vWor00_wtordr;
		/// <summary>線八年碼</summary>
		public string vWor00_year;
		/// <summary>線八單號</summary>
		public string vWor00_ordr;

		/// <summary>狀況</summary>
		public bool vWor00_sts;
		/// <summary>人工需求單</summary>
		public bool vWor00_sts1;
		/// <summary>處理進度</summary>
		public string vWor00_flow;
		/// <summary>區域號碼</summary>
		public string vWor00_pcc;
		/// <summary>訂單日期</summary>
		public DateTime vWor00_date = DateTime.Now;
		/// <summary>訂單來源</summary>
		public string vWor00_webcode;
		/// <summary>同行代碼</summary>
		public string vWor00_agent;
		/// <summary>同行類型</summary>
		public string vAgent_kind;
		/// <summary>機票開票期限yyyyMMdd</summary>
		public string vWor00_chkdate;
		/// <summary>機票開票期限HH:mm</summary>
		public string vWor00_chktime = "18:00";
		/// <summary>聯絡人id</summary>
		public string vWor00_idno;
		/// <summary>聯絡人</summary>
		public string vWor00_con_name;
		/// <summary>大人人數</summary>
		public int vWor00_act1;
		/// <summary>小孩人數</summary>
		public int vWor00_act2;
		/// <summary>嬰兒人數</summary>
		public int vWor00_act3;
		/// <summary>大人人數</summary>
		public int vWor00_act4;
		/// <summary>總金額</summary>
		public double vWor00_tot_amt;
		/// <summary>未含稅及加價金額</summary>
		public double vWor00_amt;
		/// <summary>週未加價</summary>
		public double vWor00_add_amt;
		/// <summary>折扣</summary>
		public double vWor00_discount;
		/// <summary>機場稅金</summary>
		public double vWor00_tax1 = 0;
		/// <summary>對應其他檔KEY</summary>
		public string vWor00_key1;
		/// <summary>對應其他檔KEY</summary>
		public string vWor00_key2;
		/// <summary>來自九宮格=1</summary>
		public string vWor00_key3 = string.Empty;
		/// <summary>混艙票編</summary>
		public string vWor00_key4 = string.Empty;
		/// <summary>混艙票編</summary>
		public string vWor00_key5 = string.Empty;
		/// <summary>回程OPEN</summary>
		public bool vWor00_open;
		/// <summary>訂單公司</summary>
		public string vWor00_comp;
		/// <summary>取票公司</summary>
		public string vWor00_comp2;
		/// <summary>訂單單位</summary>
		public string vWor00_prof;
		/// <summary>訂單業務</summary>
		public string vWor00_sales;
		/// <summary>訂單業務姓名</summary>
		public string vWor00_sales_name;
		/// <summary>訂單業務聯絡電話</summary>
		public string vWor00_sales_Tel;
		/// <summary>訂單業務Email</summary>
		public string vWor00_sales_Email;
		/// <summary>訂單型態</summary>
		public string vWor00_fsts;
		/// <summary>連絡人手機</summary>
		public string vWor00_con_mtel;
		/// <summary>連絡人mail</summary>
		public string vWor00_con_email;
		/// <summary>訂位系統</summary>
		public string vWor00_crs;
		/// <summary>pnr</summary>
		public string vWor00_pnr;
		/// <summary>連絡電話1</summary>
		public string vWor00_con_tel;
		public string vWor00_con_tel_1;
		public string vWor00_con_tel_3;
		/// <summary>連絡電話2</summary>
		public string vWor00_con_tel2;
		public string vWor00_con_tel2_1;
		/// <summary>取票方式 M-掛號, P-親自, D-快遞 R-到站自取</summary>
		public string vWor00_getticket = string.Empty;
		/// <summary>傳真</summary>
		public string vWor00_con_fax;
		/// <summary>註記 1- 立即網刷並開票</summary>
		public string vWor00_fsts2;
		/// <summary>專案</summary>
		public string vWor00_tkproj = string.Empty;
		public string vWor00_tkproj2 = string.Empty;
		public string vWor00_sdate = string.Empty;
		public string vWor00_fdate = string.Empty;
		public string vWor00_tdate = string.Empty;
		public double vWor00_add_amt2 = 0;
		public int vWor00_add_amt3 = 0;
		public string vWor00_name = string.Empty;
		public string vWor00_ip;//= IPDetection.IPDetector.GetIP()
		public string vWor00_qty = string.Empty;
		public bool vUpdate = false;
		public string vWor00_cxldesc = string.Empty;
		/// <summary>航空公司</summary>
		public string vWor00_carr = string.Empty;

		public string vWor00_ordrin1 = string.Empty;
		public string vWor00_ordrin2 = string.Empty;

		public string vWor00_bu = string.Empty;
		public string vWor00_tyear = string.Empty;
		public bool vWor00_table = false;
	}
	public class wtorm01
	{
		/// <summary>備註</summary>
		public string vWor01_desc;
		/// <summary>發票抬頭</summary>
		public string vWor01_title;
		public string vWor01_invoice;
		public string vWor01_io_desc;
		public string vWor01_to;
		public string vWor01_con_postcode;
		public string vWor01_con_addr3;
		public string vWor01_con_tel;
		public string vWor01_pnrDesc;
		public string vOr20_desc_Z = string.Empty;
		public string vOr20_desc_P = string.Empty;
		public string vWor01_class = string.Empty;
		public string vWor01_carr = string.Empty;
		public string vWor01_fcity = string.Empty;
		public string vWor01_tcity = string.Empty;
		public string vWor01_city = string.Empty;
		public string vWor01_country = string.Empty;
	}
	public class wtorm10
	{
		/// <summary>旅客序號</summary>
		public int vWor10_seq;
		/// <summary>中文名</summary>
		public string vWor10_cname;
		/// <summary>英文姓</summary>
		public string vWor10_enamel;
		/// <summary>英文名</summary>
		public string vWor10_ename;
		/// <summary>性別</summary>
		public string vWor10_sex;
		/// <summary>M:大人 C:小孩 I:嬰兒</summary>
		public string vWor10_etit;
		/// <summary>生日</summary>
		public string vWor10_birth;
		public string vWor10_pnr;

		public string vWor10_country;//= Appl.Web_Country
		public string vWor10_world = string.Empty;
		public string vWor10_pssprt = string.Empty;
		public string vWor10_mtel = string.Empty;//   '手機
		public string vWor10_ssr1 = string.Empty;//   '其他項目(行程餐食)
		public string vWor10_ssr2 = string.Empty;//   '其他項目()
		public string vWor10_carr1 = string.Empty;//  '會員卡1
		public string vWor10_al_card1 = string.Empty;//   '會員卡公司1
		public string vWor10_carr2 = string.Empty;//  '會員卡2
		public string vWor10_al_card2 = string.Empty;//   '會員卡公司2
		public string vWor10_ecash = string.Empty;// 'ecash
		public string vWor10_email = string.Empty;//  'email
		public bool vWor10_Checkd = false;//       '是否要加入好友
		public string vWor10_pmark = "1";
		public double vWor10_Tax1 = 0;
		public double vWor10_amt = 0;
		public double vWor10_discount = 0;
		public double vWor10_add_amt1 = 0;
		public double vWor10_add_amt2 = 0;
		public double vWor10_tot_amt = 0;
		public int vWor10_add_amt3 = 0;
		public string vWor10_ssrstr1 = "請選擇特殊需求";
		public string vWor10_ssrstr2 = "請選擇特殊需求";
		public string vWor10_pssprt3_type;  //大陸證照類別
		public string vWor10_pssprt3;  //大陸證照號碼
		public string vWor10_cost;  //供應商成本

		public string vWor10_etit_str
		{
			get
			{
				string vReturn = "";
				switch (vWor10_etit)
				{
					case "C":
						vReturn = "小孩";
						break;
					case "I":
						vReturn = "嬰兒";
						break;
					case "O":
						vReturn = "老人";
						break;
					case "P":
						vReturn = "傷殘人士";
						break;
					case "Q":
						vReturn = "大人促銷價(限5/31前 出發)";
						break;
					default:
						vReturn = "大人";
						break;
				}
				return vReturn;
			}
		}
	}
	public class wtorm20
	{
		/// <summary>行程序號</summary>
		public int vWor20_seq;
		/// <summary>出發日</summary>
		public string vWor20_fdate;
		/// <summary>出發機場</summary>
		public string vWor20_fairport;
		/// <summary>底達機場</summary>
		public string vWor20_tairport;
		/// <summary>航空公司</summary>
		public string vWor20_carr;
		/// <summary>航班編號</summary>
		public string vWor20_flightno;
		/// <summary>艙等</summary>
		public string vWor20_class;
		/// <summary>下拉BAR {BR/C,BR/B,CI/C}</summary>
		public string vWor20_carr_option;
		/// <summary>訂位狀態c2</summary>
		public string vWor20_sts = string.Empty;
		/// <summary>出發時間c4</summary>
		public string vWor20_ftime = string.Empty;
		/// <summary>抵達時間c4</summary>
		public string vWor20_ttime = string.Empty;
		/// <summary>抵達日期c8</summary>
		public string vWor20_tdate = string.Empty;
		///<summary>小三通出發地</summary>
		public string vWor20_fcity2 = string.Empty;
		///<summary>小三通目的地</summary>
		public string vWor20_tcity2 = string.Empty;
		/// <summary>神秘航空-選擇時段下拉bar</summary>
		public string vWor20_timerange_option = string.Empty;
		/// <summary>可飛行日(1234567 or 123---7)</summary>
		public string vFlyWeekDays = string.Empty;
		/// <summary>去回</summary>
		public string vComeback = string.Empty;
		/// <summary>機型</summary>
		public string vWor20_equipment = string.Empty;
		/// <summary>飛行時間</summary>
		public string vWor20_flytime = string.Empty;

		public string vWor20_codeshare = string.Empty;

		public bool? vWor20_comeback;

	}
	public class Tkpcm00
	{
		public string ipcc { get; set; }
		public string epr { get; set; }
		public string password { get; set; }
		public bool main_ipcc { get; set; }
		public string bridging_ipcc { get; set; }
		public string currency { get; set; }
		public string prodProf { get; set; }
		public string agent { get; set; }
		public string crs { get; set; }
		public string ate_issue_pcc { get; set; }
		public string ate_issue_qbox { get; set; }
		public decimal tc_addPercent { get; set; }
		public string tc_addRule { get; set; }
		public decimal tc_addAmt { get; set; }
		public decimal tc_addAmt2 { get; set; }
		public int tc_scale { get; set; }
	}
	public class Tstkm00
	{
		public string tick_tkno;
		public string tick_tkseq;
		public string tick_prof;
		public string tick_year;
		public string tick_ordr;
		public string tick_seq;
		public string tick_fdate;
		public string tick_rtid;
		public string tick_cls;
		public string tick_carr1;
		public string tick_carr4;
		public double tick_tot_cost()
		{
			decimal t = (decimal)(tick_cost * tick_erat);
			return (double)System.Math.Round(t, 0, System.MidpointRounding.AwayFromZero);
		}
		//public double tick_tot_amt() {
		//	decimal t = (decimal)(tick_cost * tick_erat);
		//	return (double)System.Math.Round(t, 0, System.MidpointRounding.AwayFromZero);
		//}
		public double tick_tot_amt;
		public double tick_cost;
		public double tick_erat;
		public string tick_etit;
		public string tick_ename;
		public string tick_air;
		public int tick_cnt;
		public string tick_desc;
		public string tick_mstfn;
		public string tick_agent2;
		public string tick_agent;
		public string tick_curr;
		public string tick_cost_curr;
		public string tick_tkperiod;
		public int tick_qtax;
		public string tick_rpt;
		public string tick_tktype;
		public int tick_rec_amt9;
		public int tick_rec_amt91;
		public int tick_gamt;
		public int tick_gamt_comp;

		public Tstkm00()
		{
			tick_tkno = string.Empty;
			tick_tkseq = string.Empty;
			tick_prof = string.Empty;
			tick_year = string.Empty;
			tick_ordr = string.Empty;
			tick_seq = string.Empty;
			tick_fdate = string.Empty;
			tick_rtid = string.Empty;
			tick_cls = string.Empty;
			tick_carr1 = string.Empty;
			tick_carr4 = string.Empty;
			tick_cost = 0;
			tick_tot_amt = 0;
			tick_erat = 1;
			tick_etit = string.Empty;
			tick_ename = string.Empty;
			tick_air = string.Empty;
			tick_cnt = 1;
			tick_desc = string.Empty;
			tick_mstfn = string.Empty;
			tick_agent2 = string.Empty;
			tick_agent = string.Empty;
			tick_curr = string.Empty;
			tick_cost_curr = string.Empty;
			tick_tkperiod = string.Empty;
			tick_qtax = 0;
			tick_rpt = string.Empty;
			tick_tktype = string.Empty;
			tick_rec_amt9 = 0;
			tick_rec_amt91 = 0;
			tick_gamt = 0;
			tick_gamt_comp = 0;
		}
	}
	public class LogTstkm50
	{
		public string Ltk50_pnr;
		public string Ltk50_date;
		public string Ltk50_wtyear;
		public string Ltk50_wtordr;
		public string Ltk50_output;
		public string Ltk50_step;
		public string Ltk50_sts;
		public string Ltk50_reason;

		public LogTstkm50()
		{
			Ltk50_pnr = string.Empty;
			Ltk50_date = string.Empty;
			Ltk50_wtyear = string.Empty;
			Ltk50_wtordr = string.Empty;
			Ltk50_output = string.Empty;
			Ltk50_step = string.Empty;
			Ltk50_sts = string.Empty;
			Ltk50_reason = string.Empty;
		}
	}
	public class IssueTicketRQ
	{
		#region 傳入的參數
		public string pcc { get; set; }
		public string crs { get; set; }
		public string pd00_carr { get; set; }
		public List<string> pnrs { get; set; }
		public List<CrsLion.Pax> paxs { get; set; }
		public string wor00_wtyear { get; set; }
		public string wor00_wtordr { get; set; }
		//public int wor00_act2 { get; set; }
		public string pd00_farebasis { get; set; }
		public string pd00_TourCode { get; set; }
		public string pd00_paytype { get; set; }
		public int pd00_paymentType { get; set; }
		public string invPaymentContent { get; set; }   //企業代碼暫時不會傳資料進來
		public string pr00_farebasis1 { get; set; }
		public string pr00_farebasis2 { get; set; }
		public string pr00_issueType { get; set; }
		public double pr00_tc_amt1 { get; set; }
		public double pr00_tc_amt2 { get; set; }
		public double pr00_a_amt1 { get; set; }
		public double pr00_a_amt2 { get; set; }
		public bool pr00_ux { get; set; }
		public string pr00_enbox1 { get; set; }
		public string pr00_enbox2 { get; set; }
		public string pd00_tkproj { get; set; }
		public string pd00_tkproj2 { get; set; }
		public bool isidenticalAmt { get; set; }
		public double kp { get; set; }
		public string ptr { get; set; }
		public string dsiv { get; set; }
		public double keepQTax { get; set; }
		public bool noQ { get; set; }
		public bool resumCaQTax { get; set; }
		public int qTax { get; set; }
		public int ltk05_tax1 { get; set; }
		public int ltk05_tax2 { get; set; }
		public bool isprintEticket { get; set; }


		// 原para---------
		public string bg00_rtid { get; set; }
		public string bg00_rtidseq { get; set; }
		public bool isRtid { get; set; }
		public string Tick_tkperiod { get; set; }
		// 原para---------

		public List<Opagm17> Opagm17s { get; set; }

		public List<QTax> qTaxList { get { return _qTaxList; } set { _qTaxList = value; } }
		private List<QTax> _qTaxList = new List<QTax>();

		public IssueTicketRQ()
			: base()
		{
			pnrs = new List<string>();
			paxs = new List<CrsLion.Pax>();
			invPaymentContent = string.Empty;
			pr00_farebasis1 = string.Empty;
			pr00_farebasis2 = string.Empty;
			pr00_ux = false;
			kp = 0;
			pr00_enbox1 = string.Empty;
			pr00_enbox2 = string.Empty;
			keepQTax = 0;
			isprintEticket = true;
			Opagm17s = new List<Opagm17>();
			qTaxList = new List<QTax>();
			resumCaQTax = false;
		}

		#endregion
	}
	public class Opagm17
	{
		public string ag17_carr { get; set; }
		public string ag17_rule { get; set; }
		public string ag17_bcode { get; set; }
	}
	public class QTax
	{
		public double amount { get; set; }
		public string Description { get; set; }
		public double roe { get; set; }
		public double qTax
		{
			get
			{
				return Math.Round(amount * roe, MidpointRounding.AwayFromZero);
			}
		}
	}
	public class setTranOrderViewModel
	{
		public string webmember { get; set; }
		public string outyear { get; set; }
		
		public string outordr { get; set; }
		
		public string prof { get; set; }

		public string fdate { get; set; }

		public string sendMessage { get; set; }
	}
	public class setTcOrderViewModel
	{
		public List<Tstkm00> tTstkm00s { get; set; }
		public string wtYear { get; set; }
		public string wtOrdr { get; set; }
		public setTcOrderViewModel()
		{
			tTstkm00s = new List<Tstkm00>();
		}
	}	

	#region BFM PricedItineraryType
	namespace BfmPricedItinerary
	{
		[XmlRoot(ElementName = "DepartureAirport", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class DepartureAirport
		{
			[XmlAttribute(AttributeName = "LocationCode")]
			public string LocationCode { get; set; }
			[XmlAttribute(AttributeName = "TerminalID")]
			public string TerminalID { get; set; }
		}

		[XmlRoot(ElementName = "ArrivalAirport", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class ArrivalAirport
		{
			[XmlAttribute(AttributeName = "LocationCode")]
			public string LocationCode { get; set; }
			[XmlAttribute(AttributeName = "TerminalID")]
			public string TerminalID { get; set; }
		}

		[XmlRoot(ElementName = "OperatingAirline", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class OperatingAirline
		{
			[XmlAttribute(AttributeName = "Code")]
			public string Code { get; set; }
			[XmlAttribute(AttributeName = "FlightNumber")]
			public string FlightNumber { get; set; }
		}

		[XmlRoot(ElementName = "Equipment", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Equipment
		{
			[XmlAttribute(AttributeName = "AirEquipType")]
			public string AirEquipType { get; set; }
		}

		[XmlRoot(ElementName = "MarketingAirline", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class MarketingAirline
		{
			[XmlAttribute(AttributeName = "Code")]
			public string Code { get; set; }
		}

		[XmlRoot(ElementName = "DepartureTimeZone", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class DepartureTimeZone
		{
			[XmlAttribute(AttributeName = "GMTOffset")]
			public string GMTOffset { get; set; }
		}

		[XmlRoot(ElementName = "ArrivalTimeZone", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class ArrivalTimeZone
		{
			[XmlAttribute(AttributeName = "GMTOffset")]
			public string GMTOffset { get; set; }
		}

		[XmlRoot(ElementName = "eTicket", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class ETicket
		{
			[XmlAttribute(AttributeName = "Ind")]
			public string Ind { get; set; }
		}

		[XmlRoot(ElementName = "TPA_Extensions", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class TPA_Extensions
		{
			[XmlElement(ElementName = "eTicket", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public ETicket ETicket { get; set; }
			[XmlElement(ElementName = "Surcharges", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public Surcharges Surcharges { get; set; }
			[XmlElement(ElementName = "Messages", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public Messages Messages { get; set; }
			[XmlElement(ElementName = "BaggageInformationList", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public BaggageInformationList BaggageInformationList { get; set; }
			[XmlElement(ElementName = "FareCalcLine", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public FareCalcLine FareCalcLine { get; set; }
			[XmlElement(ElementName = "SeatsRemaining", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public SeatsRemaining SeatsRemaining { get; set; }
			[XmlElement(ElementName = "Cabin", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public Cabin Cabin { get; set; }
			[XmlElement(ElementName = "Meal", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public Meal Meal { get; set; }
			[XmlElement(ElementName = "DivideInParty", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public DivideInParty DivideInParty { get; set; }
			[XmlElement(ElementName = "ValidatingCarrier", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public ValidatingCarrier ValidatingCarrier { get; set; }
			[XmlAttribute(AttributeName = "xmlns")]
			public string Xmlns { get; set; }
		}

		[XmlRoot(ElementName = "FlightSegment", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class FlightSegment
		{
			[XmlElement(ElementName = "DepartureAirport", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public DepartureAirport DepartureAirport { get; set; }
			[XmlElement(ElementName = "ArrivalAirport", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public ArrivalAirport ArrivalAirport { get; set; }
			[XmlElement(ElementName = "OperatingAirline", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public OperatingAirline OperatingAirline { get; set; }
			[XmlElement(ElementName = "Equipment", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public Equipment Equipment { get; set; }
			[XmlElement(ElementName = "MarketingAirline", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public MarketingAirline MarketingAirline { get; set; }
			[XmlElement(ElementName = "MarriageGrp", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public string MarriageGrp { get; set; }
			[XmlElement(ElementName = "DepartureTimeZone", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public DepartureTimeZone DepartureTimeZone { get; set; }
			[XmlElement(ElementName = "ArrivalTimeZone", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public ArrivalTimeZone ArrivalTimeZone { get; set; }
			[XmlElement(ElementName = "TPA_Extensions", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TPA_Extensions TPA_Extensions { get; set; }
			[XmlAttribute(AttributeName = "DepartureDateTime")]
			public string DepartureDateTime { get; set; }
			[XmlAttribute(AttributeName = "ArrivalDateTime")]
			public string ArrivalDateTime { get; set; }
			[XmlAttribute(AttributeName = "StopQuantity")]
			public string StopQuantity { get; set; }
			[XmlAttribute(AttributeName = "FlightNumber")]
			public string FlightNumber { get; set; }
			[XmlAttribute(AttributeName = "ResBookDesigCode")]
			public string ResBookDesigCode { get; set; }
			[XmlAttribute(AttributeName = "ElapsedTime")]
			public string ElapsedTime { get; set; }
			[XmlElement(ElementName = "DisclosureAirline", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public DisclosureAirline DisclosureAirline { get; set; }
		}

		[XmlRoot(ElementName = "OriginDestinationOption", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class OriginDestinationOption
		{
			[XmlElement(ElementName = "FlightSegment", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public List<FlightSegment> FlightSegment { get; set; }
			[XmlAttribute(AttributeName = "ElapsedTime")]
			public string ElapsedTime { get; set; }
		}

		[XmlRoot(ElementName = "DisclosureAirline", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class DisclosureAirline
		{
			[XmlAttribute(AttributeName = "Code")]
			public string Code { get; set; }
		}

		[XmlRoot(ElementName = "OriginDestinationOptions", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class OriginDestinationOptions
		{
			[XmlElement(ElementName = "OriginDestinationOption", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public List<OriginDestinationOption> OriginDestinationOption { get; set; }
		}

		[XmlRoot(ElementName = "AirItinerary", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class AirItinerary
		{
			[XmlElement(ElementName = "OriginDestinationOptions", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public OriginDestinationOptions OriginDestinationOptions { get; set; }
			[XmlAttribute(AttributeName = "DirectionInd")]
			public string DirectionInd { get; set; }
			[XmlAttribute(AttributeName = "xmlns")]
			public string Xmlns { get; set; }
		}

		[XmlRoot(ElementName = "BaseFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class BaseFare
		{
			[XmlAttribute(AttributeName = "CurrencyCode")]
			public string CurrencyCode { get; set; }
			[XmlAttribute(AttributeName = "DecimalPlaces")]
			public string DecimalPlaces { get; set; }
			[XmlAttribute(AttributeName = "Amount")]
			public string Amount { get; set; }
		}

		[XmlRoot(ElementName = "FareConstruction", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class FareConstruction
		{
			[XmlAttribute(AttributeName = "CurrencyCode")]
			public string CurrencyCode { get; set; }
			[XmlAttribute(AttributeName = "DecimalPlaces")]
			public string DecimalPlaces { get; set; }
			[XmlAttribute(AttributeName = "Amount")]
			public string Amount { get; set; }
		}

		[XmlRoot(ElementName = "EquivFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class EquivFare
		{
			[XmlAttribute(AttributeName = "CurrencyCode")]
			public string CurrencyCode { get; set; }
			[XmlAttribute(AttributeName = "DecimalPlaces")]
			public string DecimalPlaces { get; set; }
			[XmlAttribute(AttributeName = "Amount")]
			public string Amount { get; set; }
		}

		[XmlRoot(ElementName = "Tax", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Tax
		{
			[XmlAttribute(AttributeName = "CurrencyCode")]
			public string CurrencyCode { get; set; }
			[XmlAttribute(AttributeName = "DecimalPlaces")]
			public string DecimalPlaces { get; set; }
			[XmlAttribute(AttributeName = "TaxCode")]
			public string TaxCode { get; set; }
			[XmlAttribute(AttributeName = "Amount")]
			public string Amount { get; set; }
		}

		[XmlRoot(ElementName = "Taxes", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Taxes
		{
			[XmlElement(ElementName = "Tax", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public List<Tax> Tax { get; set; }
			[XmlElement(ElementName = "TotalTax", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TotalTax TotalTax { get; set; }
		}

		[XmlRoot(ElementName = "TotalFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class TotalFare
		{
			[XmlAttribute(AttributeName = "CurrencyCode")]
			public string CurrencyCode { get; set; }
			[XmlAttribute(AttributeName = "DecimalPlaces")]
			public string DecimalPlaces { get; set; }
			[XmlAttribute(AttributeName = "Amount")]
			public string Amount { get; set; }
		}

		[XmlRoot(ElementName = "ItinTotalFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class ItinTotalFare
		{
			[XmlElement(ElementName = "BaseFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public BaseFare BaseFare { get; set; }
			[XmlElement(ElementName = "FareConstruction", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public FareConstruction FareConstruction { get; set; }
			[XmlElement(ElementName = "EquivFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public EquivFare EquivFare { get; set; }
			[XmlElement(ElementName = "Taxes", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public Taxes Taxes { get; set; }
			[XmlElement(ElementName = "TotalFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TotalFare TotalFare { get; set; }
		}

		[XmlRoot(ElementName = "PassengerTypeQuantity", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class PassengerTypeQuantity
		{
			[XmlAttribute(AttributeName = "Code")]
			public string Code { get; set; }
			[XmlAttribute(AttributeName = "Quantity")]
			public string Quantity { get; set; }
		}

		[XmlRoot(ElementName = "FareBasisCode", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class FareBasisCode
		{
			[XmlAttribute(AttributeName = "BookingCode")]
			public string BookingCode { get; set; }
			[XmlAttribute(AttributeName = "DepartureAirportCode")]
			public string DepartureAirportCode { get; set; }
			[XmlAttribute(AttributeName = "ArrivalAirportCode")]
			public string ArrivalAirportCode { get; set; }
			[XmlText]
			public string Text { get; set; }
			[XmlAttribute(AttributeName = "AvailabilityBreak")]
			public string AvailabilityBreak { get; set; }
		}

		[XmlRoot(ElementName = "FareBasisCodes", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class FareBasisCodes
		{
			[XmlElement(ElementName = "FareBasisCode", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public List<FareBasisCode> FareBasisCode { get; set; }
		}

		[XmlRoot(ElementName = "TotalTax", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class TotalTax
		{
			[XmlAttribute(AttributeName = "CurrencyCode")]
			public string CurrencyCode { get; set; }
			[XmlAttribute(AttributeName = "DecimalPlaces")]
			public string DecimalPlaces { get; set; }
			[XmlAttribute(AttributeName = "Amount")]
			public string Amount { get; set; }
		}

		[XmlRoot(ElementName = "Surcharges", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Surcharges
		{
			[XmlAttribute(AttributeName = "Ind")]
			public string Ind { get; set; }
			[XmlAttribute(AttributeName = "Type")]
			public string Type { get; set; }
			[XmlText]
			public string Text { get; set; }
		}

		[XmlRoot(ElementName = "Message", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Message
		{
			[XmlAttribute(AttributeName = "AirlineCode")]
			public string AirlineCode { get; set; }
			[XmlAttribute(AttributeName = "Type")]
			public string Type { get; set; }
			[XmlAttribute(AttributeName = "FailCode")]
			public string FailCode { get; set; }
			[XmlAttribute(AttributeName = "Info")]
			public string Info { get; set; }
		}

		[XmlRoot(ElementName = "Messages", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Messages
		{
			[XmlElement(ElementName = "Message", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public List<Message> Message { get; set; }
		}

		[XmlRoot(ElementName = "Segment", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Segment
		{
			[XmlAttribute(AttributeName = "Id")]
			public string Id { get; set; }
		}

		[XmlRoot(ElementName = "Allowance", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Allowance
		{
			[XmlAttribute(AttributeName = "Pieces")]
			public string Pieces { get; set; }
		}

		[XmlRoot(ElementName = "BaggageInformation", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class BaggageInformation
		{
			[XmlElement(ElementName = "Segment", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public List<Segment> Segment { get; set; }
			[XmlElement(ElementName = "Allowance", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public Allowance Allowance { get; set; }
		}

		[XmlRoot(ElementName = "BaggageInformationList", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class BaggageInformationList
		{
			[XmlElement(ElementName = "BaggageInformation", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public List<BaggageInformation> BaggageInformation { get; set; }
		}

		[XmlRoot(ElementName = "PassengerFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class PassengerFare
		{
			[XmlElement(ElementName = "BaseFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public BaseFare BaseFare { get; set; }
			[XmlElement(ElementName = "FareConstruction", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public FareConstruction FareConstruction { get; set; }
			[XmlElement(ElementName = "EquivFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public EquivFare EquivFare { get; set; }
			[XmlElement(ElementName = "Taxes", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public Taxes Taxes { get; set; }
			[XmlElement(ElementName = "TotalFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TotalFare TotalFare { get; set; }
			[XmlElement(ElementName = "TPA_Extensions", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TPA_Extensions TPA_Extensions { get; set; }
		}

		[XmlRoot(ElementName = "Endorsements", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Endorsements
		{
			[XmlAttribute(AttributeName = "NonRefundableIndicator")]
			public string NonRefundableIndicator { get; set; }
		}

		[XmlRoot(ElementName = "FareCalcLine", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class FareCalcLine
		{
			[XmlAttribute(AttributeName = "Info")]
			public string Info { get; set; }
		}

		[XmlRoot(ElementName = "SeatsRemaining", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class SeatsRemaining
		{
			[XmlAttribute(AttributeName = "Number")]
			public string Number { get; set; }
			[XmlAttribute(AttributeName = "BelowMin")]
			public string BelowMin { get; set; }
		}

		[XmlRoot(ElementName = "Cabin", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Cabin
		{
			[XmlAttribute(AttributeName = "Cabin")]
			public string _Cabin { get; set; }
		}

		[XmlRoot(ElementName = "FareInfo", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class FareInfo
		{
			[XmlElement(ElementName = "FareReference", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public string FareReference { get; set; }
			[XmlElement(ElementName = "TPA_Extensions", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TPA_Extensions TPA_Extensions { get; set; }
		}

		[XmlRoot(ElementName = "Meal", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class Meal
		{
			[XmlAttribute(AttributeName = "Code")]
			public string Code { get; set; }
		}

		[XmlRoot(ElementName = "FareInfos", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class FareInfos
		{
			[XmlElement(ElementName = "FareInfo", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public List<FareInfo> FareInfo { get; set; }
		}

		[XmlRoot(ElementName = "PTC_FareBreakdown", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class PTC_FareBreakdown
		{
			[XmlElement(ElementName = "PassengerTypeQuantity", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public PassengerTypeQuantity PassengerTypeQuantity { get; set; }
			[XmlElement(ElementName = "FareBasisCodes", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public FareBasisCodes FareBasisCodes { get; set; }
			[XmlElement(ElementName = "PassengerFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public PassengerFare PassengerFare { get; set; }
			[XmlElement(ElementName = "Endorsements", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public Endorsements Endorsements { get; set; }
			[XmlElement(ElementName = "TPA_Extensions", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TPA_Extensions TPA_Extensions { get; set; }
			[XmlElement(ElementName = "FareInfos", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public FareInfos FareInfos { get; set; }
		}

		[XmlRoot(ElementName = "PTC_FareBreakdowns", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class PTC_FareBreakdowns
		{
			[XmlElement(ElementName = "PTC_FareBreakdown", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public List<PTC_FareBreakdown> PTC_FareBreakdown { get; set; }
		}

		[XmlRoot(ElementName = "DivideInParty", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class DivideInParty
		{
			[XmlAttribute(AttributeName = "Indicator")]
			public string Indicator { get; set; }
		}

		[XmlRoot(ElementName = "AirItineraryPricingInfo", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class AirItineraryPricingInfo
		{
			[XmlElement(ElementName = "ItinTotalFare", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public ItinTotalFare ItinTotalFare { get; set; }
			[XmlElement(ElementName = "PTC_FareBreakdowns", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public PTC_FareBreakdowns PTC_FareBreakdowns { get; set; }
			[XmlElement(ElementName = "FareInfos", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public FareInfos FareInfos { get; set; }
			[XmlElement(ElementName = "TPA_Extensions", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TPA_Extensions TPA_Extensions { get; set; }
			[XmlAttribute(AttributeName = "PricingSource")]
			public string PricingSource { get; set; }
			[XmlAttribute(AttributeName = "PricingSubSource")]
			public string PricingSubSource { get; set; }
			[XmlAttribute(AttributeName = "FareReturned")]
			public string FareReturned { get; set; }
			[XmlAttribute(AttributeName = "xmlns")]
			public string Xmlns { get; set; }
		}

		[XmlRoot(ElementName = "TicketingInfo", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class TicketingInfo
		{
			[XmlAttribute(AttributeName = "TicketType")]
			public string TicketType { get; set; }
			[XmlAttribute(AttributeName = "ValidInterline")]
			public string ValidInterline { get; set; }
			[XmlAttribute(AttributeName = "xmlns")]
			public string Xmlns { get; set; }
		}

		[XmlRoot(ElementName = "ValidatingCarrier", Namespace = "http://www.opentravel.org/OTA/2003/05")]
		public class ValidatingCarrier
		{
			[XmlAttribute(AttributeName = "Code")]
			public string Code { get; set; }
		}

		[XmlRoot(ElementName = "PricedItineraryType")]
		public class PricedItineraryType
		{
			[XmlElement(ElementName = "AirItinerary", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public AirItinerary AirItinerary { get; set; }
			[XmlElement(ElementName = "AirItineraryPricingInfo", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public AirItineraryPricingInfo AirItineraryPricingInfo { get; set; }
			[XmlElement(ElementName = "TicketingInfo", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TicketingInfo TicketingInfo { get; set; }
			[XmlElement(ElementName = "TPA_Extensions", Namespace = "http://www.opentravel.org/OTA/2003/05")]
			public TPA_Extensions TPA_Extensions { get; set; }
			[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Xsi { get; set; }
			[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Xsd { get; set; }
			[XmlAttribute(AttributeName = "SequenceNumber")]
			public string SequenceNumber { get; set; }
		}

	}
	#endregion
}
