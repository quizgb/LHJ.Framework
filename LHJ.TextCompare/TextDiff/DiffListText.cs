using System;
using System.Collections;

namespace LHJ.TextCompare.TextDiff
{
    internal class DiffListText : IDiffList
    {
        private const int MaxLineLength = 1024;
        private ArrayList _lines;

        public DiffListText(string pText)
        {
            this._lines = new ArrayList();
            string str = pText.Replace("\r\n", "\n");
            char[] chArray = new char[1] { '\n' };
            foreach (string pStr in str.Split(chArray))
                this._lines.Add((object)new TextLine(pStr));
        }

        public int Count()
        {
            return this._lines.Count;
        }

        public IComparable GetByIndex(int index)
        {
            return (IComparable)this._lines[index];
        }
    }
}
