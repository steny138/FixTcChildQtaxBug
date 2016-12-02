using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrsLion//LionExAPI.TK.Models.ViewModels.segment
{

    //public class getSegment
    //{
    //    public string arrCity { get; set; }
    //    public string depCity { get; set; }
    //    public string directFly { get; set; }
    //    public string goDate { get; set; }
    //    public string airLine{ get; set; }
    //    public int pageCap { get; set; }
    //    public int page { get; set; }
    //    public string cultureId { get; set; }
    //}
    
    /// <summary>
    /// 航段類別
    /// </summary>
    public class AirSegment
    {
        /// <summary>
        /// 去回程
        /// </summary>
        public string Comeback { get; set; }
        /// <summary>
        /// 出發城市或機場
        /// </summary>
        public string DeptCity { get; set; }
        /// <summary>
        /// 抵達城市或機場
        /// </summary>
        public string ArrCity { get; set; }
        /// <summary>
        /// 出發年
        /// </summary>
        public string Year { get; set; }
        /// <summary>
        /// 出發月
        /// </summary>
        public string Month { get; set; }
        /// <summary>
        /// 出發日
        /// </summary>
        public string DayOfMonth { get; set; }
        /// <summary>
        /// Time(HH:mm)
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 航空公司
        /// </summary>
        public string AddAirLine { get; set; }
        /// <summary>
        /// 艙等
        /// </summary>
        public string ClassCode { get; set; }
        /// <summary>
        /// 轉機點
        /// </summary>
        public string AddConnCity { get; set; }
        /// <summary>
        /// 聯營
        /// </summary>
        public string CodeShare { get; set; }
        /// <summary>
        /// 聯營限制 可搭的航空公司
        /// </summary>
        public string Codedhare2 { get; set; }
        /// <summary>
        /// 限禁搭時間1(起)
        /// </summary>
        public string Pd10Ftime1 { get; set; }
        /// <summary>
        /// 限禁搭時間1(迄)
        /// </summary>
        public string Pd10Ttime1 { get; set; }
        /// <summary>
        /// 限禁搭時間2(起)
        /// </summary>
        public string Pd10Ftime2 { get; set; }
        /// <summary>
        /// 限禁搭時間2(迄)
        /// </summary>
        public string Pd10Ttime2 { get; set; }
        /// <summary>
        /// 限禁搭航班種類 空白-無.0-限搭,1-禁搭
        /// </summary>
        public string Pd10Kid2 { get; set; }
        /// <summary>
        /// 限禁搭航班
        /// </summary>
        public string Pd10FlightNo { get; set; }
        /// <summary>
        /// 航段出發城市
        /// </summary>
        public string SingleSegDeptCity { get; set; }
        /// <summary>
        /// 航段抵達城市
        /// </summary>
        public string SingleSegArrcity { get; set; }
        /// <summary>
        /// 航段數
        /// </summary>
        public string SegLength { get; set; }
        /// <summary>
        /// 出發地以x為主
        /// </summary>
        public string Pd00Fcity { get; set; }
        /// <summary>
        /// 最早出發日
        /// </summary>
        public string Pr00Tdate { get; set; }
        /// <summary>
        /// BackEndDate
        /// </summary>
        public string BackEndDate { get; set; }
        /// <summary>
        /// 最晚出發日
        /// </summary>
        /// <returns></returns>
        public string Pr00Fdate { get; set; }
        /// <summary>
        /// 出發起始日
        /// </summary>
        /// <returns></returns>
        public string Fdate { get; set; }
        /// <summary>
        /// 票源航空
        /// </summary>
        /// <returns></returns>
        public string Pd00Carr { get; set; }
        /// <summary>
        /// 是否要切換到airline
        /// </summary>
        /// <returns></returns>
        public bool changeToAirlineHost { get; set; }
        /// <summary>
        /// 來自Abacus or Amadeus的航段列表
        /// </summary>
        /// <returns></returns>
        //public System.Collections.ArrayList GDSSegments { get; set; }
        public List<List<FlightPackage.Segment>> GDSSegments { get; set; }

        public int pageCap { get; set; }
        public int page { get; set; }
    }

    /// <summary>
    /// 航空資料
    /// </summary>
    public class FlightPackage
    {
        public class Segment
        {
            /// <summary>
            /// 航空公司
            /// </summary>
            public string AirLine { get; set; }
            /// <summary>
            /// 聯營航空公司
            /// </summary>
            public string CodeShareAirLine { get; set; }
            /// <summary>
            /// 出發城市
            /// </summary>
            public string DeptCity { get; set; }
            /// <summary>
            /// 抵達城市
            /// </summary>
            public string ArrCity { get; set; }
            /// <summary>
            /// 出發日期時間
            /// </summary>
            public string DeptDateTime { get; set; }
            /// <summary>
            /// 抵達日期時間
            /// </summary>
            public string ArrDateTime { get; set; }
            /// <summary>
            /// 航班
            /// </summary>
            public string FlightNum { get; set; }
            /// <summary>
            /// 機型
            /// </summary>
            public string EquipmentCode { get; set; }
            /// <summary>
            /// 艙等
            /// </summary>
            public string ClassCode { get; set; }
            /// <summary>
            /// 可售機位
            /// </summary>
            public string SeatsCount { get; set; }
            /// <summary>
            /// 可售機位未關艙數量
            /// </summary>
            public string oSeatsCount { get; set; }
            /// <summary>
            /// 關艙
            /// </summary>
            public bool waitClosed { get; set; }

            /// <summary>
            /// 飛行日(from GDS)
            /// </summary>
            public string FlyDays;
            /// <summary>
            /// 飛行時間
            /// </summary>
            public string JourneyTime;

            public List<AvailableSeat> AvailableSeats { get; set; }
        }        
    }

    /// <summary>
    /// 行程資料
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// 航段
        /// </summary>
        public int Seq { get; set; }
        /// <summary>
        /// HK/HL
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 航空公司
        /// </summary>
        public string Carr { get; set; }
        public string CarrName { get; set; }
        /// <summary>
        /// 聯營航空公司
        /// </summary>
        public string CodeShareCarr { get; set; }
        public bool CodeShare { get; set; }
        /// <summary>
        /// 艙等
        /// </summary>
        public string Cls { get; set; }
        /// <summary>
        /// 航班編號
        /// </summary>
        public string FlightNum { get; set; }
        /// <summary>
        /// 出發時間
        /// </summary>
        public string Fdate { get; set; }
        /// <summary>
        /// 抵達時間
        /// </summary>
        public string Tdate { get; set; }
        /// <summary>
        /// 出發城市
        /// </summary>
        public string Fcity { get; set; }
        public string FcityName { get; set; }
        /// <summary>
        /// 抵達城市
        /// </summary>
        public string Tcity { get; set; }
        public string TcityName { get; set; }
        /// <summary>
        /// A/L Pnr
        /// </summary>
        public string FlightPnr { get; set; }
        /// <summary>
        /// 停留次數
        /// </summary>
        public string StopCount { get; set; }
        /// <summary>
        /// 飛機型號
        /// </summary>
        public string Equipment { get; set; }
        /// <summary>
        /// 飛行時間
        /// </summary>
        public string TotalFlyTime { get; set; }
        /// <summary>
        /// 出發航廈
        /// </summary>
        public string Fterminal { get; set; }
        /// <summary>
        /// 抵達航廈
        /// </summary>
        public string Tterminal { get; set; }
        /// <summary>
        /// 資訊在PNR裡的第幾行
        /// </summary>
        public string SegNo { get; set; }
        /// <summary>
        /// 來回
        /// </summary>
        public string ComeBack { get; set; }
        /// <summary>
        /// 航段哩程數
        /// </summary>
        public string airMiles { get; set; }
        /// <summary>
        /// 班次(每天或12345日
        /// </summary>
        public string Flyday { get; set; }
    }

    public class AvailableSeat
    {
        public string SeatCount { get; set; }
        public string SeatClass { get; set; }
        bool waitClosed { get; set; }
        /// <summary>
        /// 大人價錢
        /// </summary>
        int Disc_amt1 { get; set; }
        /// <summary>
        /// 小孩價錢
        /// </summary>
        int Disc_amt2 { get; set; }
        /// <summary>
        /// 停留點加價
        /// </summary>
        string Stop_amt { get; set; }
        /// <summary>
        /// 混艙最短停留天數
        /// </summary>
        string Days { get; set; }
        /// <summary>
        /// 混艙票期
        /// </summary>
        string Tkpriod { get; set; }
        /// <summary>
        /// 混艙票期種類
        /// </summary>
        string TkpriodKind { get; set; }
        /// <summary>
        /// 混艙票價編號
        /// </summary>
        string MixclsPrcno { get; set; }
        /// <summary>
        /// 混艙票編
        /// </summary>
        string MixclsProdno { get; set; }
        /// <summary>
        /// 是否符合規則顯示在網頁上
        /// </summary>
        bool ShowOnPage { get; set; }



    }

    #region "其他資料"
    /// <summary>
    /// amadeus使用 其他資料..例如ssr的資料
    /// </summary>
    public class other
    {
        public string OtherCode { get; set; }
        public string OtherText { get; set; }
        public string OtherPaxNo { get; set; }
        public string OtherSeqNo { get; set; }
        public string OtherSts { get; set; }

        public other()
        {
            OtherCode = "";
            OtherText = "";
            OtherPaxNo = "";
            OtherSeqNo = "";
            OtherSts = "";
        }
    }
    #endregion

    #region "旅客資料"
    public class Pax
    {
        /// <summary>
        /// 姓
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string LastName { get; set; }
        /// <summary>
        /// 名
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string FirstName { get; set; }
        /// <summary>
        /// 稱謂
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Title { get; set; }
        /// <summary>
        /// 旅客編號
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string PaxNo { get; set; }
        /// <summary>
        /// 餐食偏好
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Meal { get; set; }
        /// <summary>
        /// 坐位偏好
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Seat { get; set; }
        /// <summary>
        /// 旅客類型 M-大人,C-小孩,I-嬰兒
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Etit { get; set; }

        /// <summary>
        /// M男/F女
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Sex { get; set; }

        /// <summary>
        /// 座位資訊
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<Seat> csSeats { get; set; }

        /// <summary>
        /// 序號
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Seq { get; set; }

        /// <summary>
        /// PNR 訂位代號
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string Pnr { get; set; }
        /// <summary>
        /// 會員卡資訊
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public List<CustLoyalty> CustLoyaltys { get; set; }
        /// <summary> 該旅客開票票檔的enbox
        /// </summary>
        public int tfrRph { get; set; }
        /// <summary> 開票成本
        /// </summary>
        public int net { get; set; }
        /// <summary> 旅客類別,例:ADT C09
        /// </summary>
        public string PDValue { get; set; }

        /// <summary>票價檔內是否有net
        /// </summary>
        public bool haveNet { get; set; }
        public Pax()
        {
            LastName = "";
            FirstName = "";
            Title = "";
            PaxNo = "";
            Meal = "";
            Etit = "";
            Seat = "";
            csSeats = new List<Seat>();
            CustLoyaltys = new List<CustLoyalty>();

            tfrRph = 0;
            net = 0;
            PDValue = string.Empty;
            haveNet = false;
        }

    }
    #endregion

    #region "座位"
    public class Seat
    {
        /// <summary>旅客代號:1.1</summary>
        public string nameNumber { get; set; }
        /// <summary>座號:16B</summary>
        public string number { get; set; }
        /// <summary>座位區域</summary>
        //Property seatLocation As String
        /// <summary>狀態:HK/KK</summary>
        public string status { get; set; }
        /// <summary>航空公司</summary>'20121012
        public string airline { get; set; }
        /// <summary>航班號碼</summary>'20121012
        public string flightNum { get; set; }
        public Seat()
        {
            nameNumber = string.Empty;
            number = string.Empty;
            //seatLocation = String.Empty
            status = string.Empty;
            airline = string.Empty;
            //20121012
            flightNum = string.Empty;
            //20121012
        }
    }
    #endregion

    #region "會員卡"
    public class CustLoyalty
    {
        /// <summary>訂位航空:CI</summary>
        public string programID { get; set; }
        /// <summary>會員卡旅屬航空:CI</summary>
        public string codeShare { get; set; }
        /// <summary>卡號WB1234567</summary>
        public string MembershipID { get; set; }
        /// <summary>所屬旅客代號01.01</summary>
        public string nameNumber { get; set; }
        /// <summary>流水號001</summary>
        public string rph { get; set; }
        /// <summary>會員卡狀態HK</summary>
        public string status { get; set; }
    }
    #endregion

}
