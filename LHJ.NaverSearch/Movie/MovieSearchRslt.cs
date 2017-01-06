using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.NaverSearch.Movie
{
    public class MovieSearchRslt
    {
        public string lastBuildDate { get; set; }
        public int total { get; set; }
        public int start { get; set; }
        public int display { get; set; }
        public MovieItem[] items { get; set; }
    }
}
