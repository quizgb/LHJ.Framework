using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.NaverSearch.Shopping
{
    public class ShopSearchRslt
    {
        public string lastBuildDate { get; set; }
        public int total { get; set; }
        public int start { get; set; }
        public int display { get; set; }
        public ShopItem[] items { get; set; }
    }
}
