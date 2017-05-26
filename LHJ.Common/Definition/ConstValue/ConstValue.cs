using System;
using System.Collections.Generic;
using System.Data;
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

        public enum YoutubeDownloaderDownloadType
        {
            Video = 1,
            MP3 = 2
        }

        public struct YoutubeDownloaderDownloadType_DISPLAY
        {
            public const string VIDEO = "Video";
            public const string MP3 = "MP3";
        }

        public struct DBViewer_ObjectList_DISPLAY
        {
            public const string TABLE = "Tables";
            public const string VIEW = "Views";
            public const string FUNCTION = "Functions";
            public const string PROCEDURE = "Procedures";
            public const string TRIGGER = "Triggers";
            public const string INDEX = "Indexes";
            public const string SEQUENCE = "Sequences";
            public const string PACKAGE = "Packages";
        }

        public struct DBViewer_ObjectList_VALUE
        {
            public const string TABLE = "TABLE";
            public const string VIEW = "VIEW";
            public const string FUNCTION = "FUNCTION";
            public const string PROCEDURE = "PROCEDURE";
            public const string TRIGGER = "TRIGGER";
            public const string INDEX = "INDEX";
            public const string SEQUENCE = "SEQUENCE";
            public const string PACKAGE = "PACKAGE";
        }

        public struct DBViewer_ObjectInfo_DISPLAY
        {
            public const string COLUMN = "Columns";
            public const string DATA = "Data";
            public const string INDEX = "Indexes";
            public const string SCRIPT = "Script";
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

        public const string ENCRPT_KEY = "LHJFramework";
        public const string ServerInfoMonitorServerListFileName = "RDP.svl";
    }
}
