using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.Common.Common
{
    public static class Comm
    {
        private static LHJ.Common.Com.Wait m_Wait = new LHJ.Common.Com.Wait();
        public static LHJ.Common.Com.Wait Wait
        {
            get { return Comm.m_Wait; }
        }
    }
}
