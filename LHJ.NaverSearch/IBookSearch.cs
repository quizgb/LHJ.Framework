using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LHJ.NaverSearch
{
    interface IBookSearch
    {
        void SetFocusTitle();

        void SetSearchRsltInfo(int aStart, int aDisplay, int aTotal);

        bool CheckBeforeSearch();

        void Search(bool aNewSearchState);

        void ResizeSearchRsltCtrl();

        void ClearSearchBefore(bool aNewSearchState);
    }
}
