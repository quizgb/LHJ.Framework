using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.TextCompare.TextDiff
{
    internal enum DiffResultSpanStatus
    {
        NoChange,
        Replace,
        DeleteSource,
        AddDestination,
    }
}
