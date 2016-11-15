using System;

namespace LHJ.TextCompare.TextDiff
{
    internal class TextLine : IComparable
    {
        public string Line;
        private int _hash;

        public TextLine(string pStr)
        {
            this.Line = pStr.Replace("\t", "    ");
            this._hash = pStr.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return this._hash.CompareTo(((TextLine)obj)._hash);
        }
    }
}
