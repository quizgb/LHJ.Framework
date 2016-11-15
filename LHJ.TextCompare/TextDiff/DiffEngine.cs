using System;
using System.Collections;

namespace LHJ.TextCompare.TextDiff
{
    internal class DiffEngine
    {
        private IDiffList _source;
        private IDiffList _dest;
        private ArrayList _matchList;
        private DiffEngineLevel _level;
        private DiffStateList _stateList;

        public DiffEngine()
        {
            this._source = (IDiffList)null;
            this._dest = (IDiffList)null;
            this._matchList = (ArrayList)null;
            this._stateList = (DiffStateList)null;
            this._level = DiffEngineLevel.FastImperfect;
        }

        private int GetSourceMatchLength(int destIndex, int sourceIndex, int maxLength)
        {
            int num = 0;
            while (num < maxLength && this._dest.GetByIndex(destIndex + num).CompareTo((object)this._source.GetByIndex(sourceIndex + num)) == 0)
                ++num;
            return num;
        }

        private void GetLongestSourceMatch(DiffState curItem, int destIndex, int destEnd, int sourceStart, int sourceEnd)
        {
            int val1 = destEnd - destIndex + 1;
            int length = 0;
            int start = -1;
            for (int sourceIndex = sourceStart; sourceIndex <= sourceEnd; sourceIndex = sourceIndex + length + 1)
            {
                int maxLength = Math.Min(val1, sourceEnd - sourceIndex + 1);
                if (maxLength > length)
                {
                    int sourceMatchLength = this.GetSourceMatchLength(destIndex, sourceIndex, maxLength);
                    if (sourceMatchLength > length)
                    {
                        start = sourceIndex;
                        length = sourceMatchLength;
                    }
                }
                else
                    break;
            }
            if (start == -1)
                curItem.SetNoMatch();
            else
                curItem.SetMatch(start, length);
        }

        private void ProcessRange(int destStart, int destEnd, int sourceStart, int sourceEnd)
        {
            int destIndex = -1;
            int length = -1;
            DiffState diffState = (DiffState)null;
            for (int index = destStart; index <= destEnd; ++index)
            {
                int maxPossibleDestLength = destEnd - index + 1;
                if (maxPossibleDestLength > length)
                {
                    DiffState byIndex = this._stateList.GetByIndex(index);
                    if (!byIndex.HasValidLength(sourceStart, sourceEnd, maxPossibleDestLength))
                        this.GetLongestSourceMatch(byIndex, index, destEnd, sourceStart, sourceEnd);
                    if (byIndex.Status == DiffStatus.Matched)
                    {
                        switch (this._level)
                        {
                            case DiffEngineLevel.FastImperfect:
                                if (byIndex.Length > length)
                                {
                                    destIndex = index;
                                    length = byIndex.Length;
                                    diffState = byIndex;
                                }
                                index += byIndex.Length - 1;
                                break;
                            case DiffEngineLevel.Medium:
                                if (byIndex.Length > length)
                                {
                                    destIndex = index;
                                    length = byIndex.Length;
                                    diffState = byIndex;
                                    index += byIndex.Length - 1;
                                    break;
                                }
                                break;
                            default:
                                if (byIndex.Length > length)
                                {
                                    destIndex = index;
                                    length = byIndex.Length;
                                    diffState = byIndex;
                                    break;
                                }
                                break;
                        }
                    }
                }
                else
                    break;
            }
            if (destIndex < 0)
                return;
            int startIndex = diffState.StartIndex;
            this._matchList.Add((object)DiffResultSpan.CreateNoChange(destIndex, startIndex, length));
            if (destStart < destIndex && sourceStart < startIndex)
                this.ProcessRange(destStart, destIndex - 1, sourceStart, startIndex - 1);
            int destStart1 = destIndex + length;
            int sourceStart1 = startIndex + length;
            if (destEnd > destStart1 && sourceEnd > sourceStart1)
                this.ProcessRange(destStart1, destEnd, sourceStart1, sourceEnd);
        }

        public double ProcessDiff(IDiffList source, IDiffList destination, DiffEngineLevel level)
        {
            this._level = level;
            return this.ProcessDiff(source, destination);
        }

        public double ProcessDiff(IDiffList source, IDiffList destination)
        {
            DateTime now = DateTime.Now;
            this._source = source;
            this._dest = destination;
            this._matchList = new ArrayList();
            int destCount = this._dest.Count();
            int num = this._source.Count();
            if (destCount > 0 && num > 0)
            {
                this._stateList = new DiffStateList(destCount);
                this.ProcessRange(0, destCount - 1, 0, num - 1);
            }
            return (DateTime.Now - now).TotalSeconds;
        }

        private bool AddChanges(ArrayList report, int curDest, int nextDest, int curSource, int nextSource)
        {
            bool flag = false;
            int num1 = nextDest - curDest;
            int num2 = nextSource - curSource;
            if (num1 > 0)
            {
                if (num2 > 0)
                {
                    int length = Math.Min(num1, num2);
                    report.Add((object)DiffResultSpan.CreateReplace(curDest, curSource, length));
                    if (num1 > num2)
                    {
                        curDest += length;
                        report.Add((object)DiffResultSpan.CreateAddDestination(curDest, num1 - num2));
                    }
                    else if (num2 > num1)
                    {
                        curSource += length;
                        report.Add((object)DiffResultSpan.CreateDeleteSource(curSource, num2 - num1));
                    }
                }
                else
                    report.Add((object)DiffResultSpan.CreateAddDestination(curDest, num1));
                flag = true;
            }
            else if (num2 > 0)
            {
                report.Add((object)DiffResultSpan.CreateDeleteSource(curSource, num2));
                flag = true;
            }
            return flag;
        }

        public ArrayList DiffReport()
        {
            ArrayList report = new ArrayList();
            int num1 = this._dest.Count();
            int num2 = this._source.Count();
            if (num1 == 0)
            {
                if (num2 > 0)
                    report.Add((object)DiffResultSpan.CreateDeleteSource(0, num2));
                return report;
            }
            if (num2 == 0)
            {
                report.Add((object)DiffResultSpan.CreateAddDestination(0, num1));
                return report;
            }
            this._matchList.Sort();
            int curDest = 0;
            int curSource = 0;
            DiffResultSpan diffResultSpan = (DiffResultSpan)null;
            foreach (DiffResultSpan match in this._matchList)
            {
                if (!this.AddChanges(report, curDest, match.DestIndex, curSource, match.SourceIndex) && diffResultSpan != null)
                    diffResultSpan.AddLength(match.Length);
                else
                    report.Add((object)match);
                curDest = match.DestIndex + match.Length;
                curSource = match.SourceIndex + match.Length;
                diffResultSpan = match;
            }
            this.AddChanges(report, curDest, num1, curSource, num2);
            return report;
        }
    }
}