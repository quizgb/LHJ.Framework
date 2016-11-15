using System;

namespace LHJ.TextCompare.TextDiff
{
    internal interface IDiffList
    {
        int Count();

        IComparable GetByIndex(int index);
    }
}
