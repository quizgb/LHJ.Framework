using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.DBViewer
{
    public static class ExtensionMethod
    {
        #region ParamList에 쿼리에 바인드 할 변수명과 값을 담는다.
        /// <summary>
        /// ParamList에 쿼리에 바인드 할 변수명과 값을 담는다.
        /// </summary>
        /// <param name="aParamList"></param>
        /// <param name="aName"></param>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public static List<DBService.DBCmdParameter> AddParameter(this List<DBService.DBCmdParameter> aParamList, string aName, Object aValue)
        {
            aParamList.Add(new DBService.DBCmdParameter(aName, aValue));

            return aParamList;
        }
        #endregion ParamList에 쿼리에 바인드 할 변수명과 값을 담는다.
    }
}
