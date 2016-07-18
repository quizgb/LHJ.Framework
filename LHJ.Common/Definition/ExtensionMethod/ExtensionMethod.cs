using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LHJ.Controls;

namespace LHJ.Common.Definition
{
    public static class ExtensionMethod
    {
        #region ParamList에 쿼리에 바인드 할 변수명과 값을 담는다.
        public static List<DBService.ParamInfo> AddParameter(this List<DBService.ParamInfo> aParamList, string aName, Object aValue)
        {
            aParamList.Add(new DBService.ParamInfo(aName, aValue));

            return aParamList;
        }
        #endregion ParamList에 쿼리에 바인드 할 변수명과 값을 담는다.

        #region DataGridView의 해당 셀에 연결된 값을 가져온다.
        public static Object GetRowCellValue(this ucDataGridView aDGV, int aRowIndex, int aColIndex)
        {
            if (aDGV.Rows[aRowIndex].Cells[aColIndex].Value != null)
            {
                return aDGV.Rows[aRowIndex].Cells[aColIndex].Value;
            }

            return null;
        }

        public static Object GetRowCellValue(this ucDataGridView aDGV, int aRowIndex, string aColName)
        {
            if (aDGV.Rows[aRowIndex].Cells[aColName].Value != null)
            {
                return aDGV.Rows[aRowIndex].Cells[aColName].Value;
            }

            return null;
        }

        public static string GetRowCellStrValue(this ucDataGridView aDGV, int aRowIndex, int aColIndex)
        {
            if (aDGV.Rows[aRowIndex].Cells[aColIndex].Value != null)
            {
                return aDGV.Rows[aRowIndex].Cells[aColIndex].Value.ToString();
            }

            return string.Empty;
        }

        public static string GetRowCellStrValue(this ucDataGridView aDGV, int aRowIndex, string aColName)
        {
            if (aDGV.Rows[aRowIndex].Cells[aColName].Value != null)
            {
                return aDGV.Rows[aRowIndex].Cells[aColName].Value.ToString();
            }

            return string.Empty;
        }
        #endregion DataGridView의 해당 셀에 연결된 값을 가져온다.

        #region DataGridView의 해당 셀에 값을 넣는다.
        public static void SetRowCellValue(this ucDataGridView aDGV, int aRowIndex, int aColIndex, Object aValue)
        {
            aDGV.Rows[aRowIndex].Cells[aColIndex].Value = aValue;
        }

        public static void SetRowCellValue(this ucDataGridView aDGV, int aRowIndex, string aColName, Object aValue)
        {
            aDGV.Rows[aRowIndex].Cells[aColName].Value = aValue;
        }
        #endregion DataGridView의 해당 셀에 값을 넣는다.
    }
}
