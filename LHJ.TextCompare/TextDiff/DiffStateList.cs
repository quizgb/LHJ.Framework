namespace LHJ.TextCompare.TextDiff
{
    internal class DiffStateList
    {
        private DiffState[] _array;

        public DiffStateList(int destCount)
        {
            this._array = new DiffState[destCount];
        }

        public DiffState GetByIndex(int index)
        {
            DiffState diffState = this._array[index];
            if (diffState == null)
            {
                diffState = new DiffState();
                this._array[index] = diffState;
            }
            return diffState;
        }
    }
}
