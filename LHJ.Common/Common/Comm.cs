using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.Common
{
    public static class Comm
    {
        private static LHJ.DBService.DBWorker m_DBWorker = new LHJ.DBService.DBWorker();
        public static LHJ.DBService.DBWorker DBWorker
        {
            get { return Comm.m_DBWorker; }
        }

        private static LHJ.Common.Com.Wait m_Wait = new LHJ.Common.Com.Wait();
        public static LHJ.Common.Com.Wait Wait
        {
            get { return Comm.m_Wait; }
        }
    }
}
