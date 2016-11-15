using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.TextCompare.TextDiff
{
    internal class DiffResultSpan : IComparable
    {
        private const int BAD_INDEX = -1;
        private int _destIndex;
        private int _sourceIndex;
        private int _length;
        private DiffResultSpanStatus _status;

        public int DestIndex
        {
            get
            {
                return this._destIndex;
            }
        }

        public int SourceIndex
        {
            get
            {
                return this._sourceIndex;
            }
        }

        public int Length
        {
            get
            {
                return this._length;
            }
        }

        public DiffResultSpanStatus Status
        {
            get
            {
                return this._status;
            }
        }

        protected DiffResultSpan(DiffResultSpanStatus status, int destIndex, int sourceIndex, int length)
        {
            this._status = status;
            this._destIndex = destIndex;
            this._sourceIndex = sourceIndex;
            this._length = length;
        }

        public static DiffResultSpan CreateNoChange(int destIndex, int sourceIndex, int length)
        {
            return new DiffResultSpan(DiffResultSpanStatus.NoChange, destIndex, sourceIndex, length);
        }

        public static DiffResultSpan CreateReplace(int destIndex, int sourceIndex, int length)
        {
            return new DiffResultSpan(DiffResultSpanStatus.Replace, destIndex, sourceIndex, length);
        }

        public static DiffResultSpan CreateDeleteSource(int sourceIndex, int length)
        {
            return new DiffResultSpan(DiffResultSpanStatus.DeleteSource, -1, sourceIndex, length);
        }

        public static DiffResultSpan CreateAddDestination(int destIndex, int length)
        {
            return new DiffResultSpan(DiffResultSpanStatus.AddDestination, destIndex, -1, length);
        }

        public void AddLength(int i)
        {
            this._length += i;
        }

        public override string ToString()
        {
            return string.Format("{0} (Dest: {1},Source: {2}) {3}", (object)this._status.ToString(), (object)this._destIndex.ToString(), (object)this._sourceIndex.ToString(), (object)this._length.ToString());
        }

        public int CompareTo(object obj)
        {
            return this._destIndex.CompareTo(((DiffResultSpan)obj)._destIndex);
        }
    }
}
