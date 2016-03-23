using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.DBService
{
    public class ParamInfo
    {
        int m_size;
        string m_ParameterName;
        object m_Value;

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
    }
}
