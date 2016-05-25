using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.Common.Definition
{
    public class ConstValue
    {
        public const string MSGBOX_TITLE = "알림";

        public enum Def_DatabaseType
        {
            Oracle_OracleClient = 0,
            Oracle_OleDb = 1
        }

        public enum ProgressBarTextType
        {
            None = 1, Percentage = 2, Word = 3
        }

        public enum DBViewerFormType
        { 
            SqlWindow = 1, 
            SchemaBrowser = 2, 
            SessionViewer = 3,
            TableSpaceViewer = 4
        }

        public const int WM_PAINT = 15;
        public const string REGISTRY_EXCEL_KEY = @"Excel.Application";

        // 확장명 XLS (Excel 97~2003)
        public const string ConnectStrExcel97_2003 =
            "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=\"{0}\";" +
            "Mode=ReadWrite|Share Deny None;" +
            "Extended Properties='Excel 8.0; HDR={1}; IMEX={2}';" +
            "Persist Security Info=False";

        // 확장명 XLSX (Excel 2007 이상)
        public const string ConnectStrExcel =
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=\"{0}\";" +
            "Mode=ReadWrite|Share Deny None;" +
            "Extended Properties='Excel 12.0; HDR={1}; IMEX={2}';" +
            "Persist Security Info=False";
    }
}
