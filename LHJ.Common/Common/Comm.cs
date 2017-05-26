using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.Common
{
    public static class Comm
    {
        #region 1.Variable
        private static Program m_Pgm = new Program();
        #endregion 1.Variable


        #region 2.Property
        private static LHJ.DBService.DBWorker m_DBWorker = new LHJ.DBService.DBWorker();
        public static LHJ.DBService.DBWorker DBWorker
        {
            get { return m_DBWorker; }
        }

        private static LHJ.Common.Common.Com.Logger m_Logger = new LHJ.Common.Common.Com.Logger();
        public static LHJ.Common.Common.Com.Logger Logger
        {
            get { return m_Logger; }
        }

        private static LHJ.Common.Common.Com.Util m_Util = new LHJ.Common.Common.Com.Util();
        public static LHJ.Common.Common.Com.Util Util
        {
            get { return m_Util; }
        }

        private static LHJ.Common.Common.Com.Cryptography m_Cryptography = new LHJ.Common.Common.Com.Cryptography();
        public static LHJ.Common.Common.Com.Cryptography Cryptography
        {
            get { return m_Cryptography; }
        }
        #endregion 2.Property


        #region 3.Constructor

        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        #endregion 5.Set Initialize


        #region 6.Method

        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
