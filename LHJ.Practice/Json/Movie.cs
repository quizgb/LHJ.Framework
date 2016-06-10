using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.Practice.Json
{
    public class Movie
    {
        public Boxofficeresult boxOfficeResult { get; set; }
    }

    public class Boxofficeresult
    {
        public string boxofficeType { get; set; }
        public string showRange { get; set; }
        public Dailyboxofficelist[] dailyBoxOfficeList { get; set; }
    }

    public class Dailyboxofficelist
    {
        public string rnum { get; set; }
        public string rank { get; set; }
        public string rankInten { get; set; }
        public string rankOldAndNew { get; set; }
        public string movieCd { get; set; }
        public string movieNm { get; set; }
        public string openDt { get; set; }
        public string salesAmt { get; set; }
        public string salesShare { get; set; }
        public string salesInten { get; set; }
        public string salesChange { get; set; }
        public string salesAcc { get; set; }
        public string audiCnt { get; set; }
        public string audiInten { get; set; }
        public string audiChange { get; set; }
        public string audiAcc { get; set; }
        public string scrnCnt { get; set; }
        public string showCnt { get; set; }
    }
}
