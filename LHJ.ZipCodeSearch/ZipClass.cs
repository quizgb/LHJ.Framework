using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.ZipCodeSearch
{
    public class ZipClass
    {
        public Detaillistresponse DetailListResponse { get; set; }

        public class Detaillistresponse
        {
            public Cmmmsgheader cmmMsgHeader { get; set; }
            public Detaillistareacd[] detailListAreaCd { get; set; }
        }

        public class Cmmmsgheader
        {
            public string countPerPage { get; set; }
            public string currentPage { get; set; }
            public object errMsg { get; set; }
            public object requestMsgId { get; set; }
            public object responseMsgId { get; set; }
            public string responseTime { get; set; }
            public string returnCode { get; set; }
            public string successYN { get; set; }
            public string totalCount { get; set; }
            public string totalPage { get; set; }
        }

        public class Detaillistareacd
        {
            public string adres { get; set; }
            public string no { get; set; }
            public string zipNo { get; set; }
        }
    }
}
