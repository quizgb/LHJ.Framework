using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LHJ.TextCompare.TextDiff
{
    internal class DiffState
    {
        private const int BAD_INDEX = -1;
        private int _startIndex;
        private int _length;

        public int StartIndex
        {
            get
            {
                return this._startIndex;
            }
        }

        public int EndIndex
        {
            get
            {
                return this._startIndex + this._length - 1;
            }
        }

        public int Length
        {
            get
            {
                return this._length <= 0 ? (this._length != 0 ? 0 : 1) : this._length;
            }
        }

        public DiffStatus Status
        {
            get
            {
                DiffStatus diffStatus;
                if (this._length > 0)
                    diffStatus = DiffStatus.Matched;
                else if (this._length == -1)
                {
                    diffStatus = DiffStatus.NoMatch;
                }
                else
                {
                    Debug.Assert(this._length == -2, "Invalid status: _length < -2");
                    diffStatus = DiffStatus.Unknown;
                }
                return diffStatus;
            }
        }

        public DiffState()
        {
            this.SetToUnkown();
        }

        protected void SetToUnkown()
        {
            this._startIndex = -1;
            this._length = -2;
        }

        public void SetMatch(int start, int length)
        {
            Debug.Assert(length > 0, "Length must be greater than zero");
            Debug.Assert(start >= 0, "Start must be greater than or equal to zero");
            this._startIndex = start;
            this._length = length;
        }

        public void SetNoMatch()
        {
            this._startIndex = -1;
            this._length = -1;
        }

        public bool HasValidLength(int newStart, int newEnd, int maxPossibleDestLength)
        {
            if (this._length > 0 && (maxPossibleDestLength < this._length || (this._startIndex < newStart || this.EndIndex > newEnd)))
                this.SetToUnkown();
            return this._length != -2;
        }
    }
}
