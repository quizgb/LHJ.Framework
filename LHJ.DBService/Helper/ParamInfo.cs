using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.DBService
{
    public class ParamInfo
    {
        #region 1.Variable
        int m_size;
        string m_ParameterName;
        object m_Value;
        #endregion 1.Variable


        #region 2.Property
        public string ParameterName
        {
            get { return m_ParameterName; }
        }

        public object Value
        {
            get { return m_Value; }
        }

        private int Size
        {
            get { return m_size; }
        }
        #endregion 2.Property


        #region 3.Constructor
        public ParamInfo(string ParameterName, object Value)
        {
            m_ParameterName = ParameterName;
            m_Value = Value;
        }

        private ParamInfo(string ParameterName, int Size, object Value)
        {
            m_size = Size;
            m_ParameterName = ParameterName;
            m_Value = Value;
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {

        }
        #endregion 5.Set Initialize


        #region 6.Method

        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
