using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LHJ.DBService;
using LHJ.Common.Definition;

namespace LHJ.DBViewer
{
    public static class DALDataAccess
    {
        public static DataTable GetSessionSQL(string aSID)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @"  SELECT to_char(SQL_FULLTEXT) sql_text  
                               FROM V$SQL  
                              WHERE ADDRESS IN ( SELECT SQL_ADDRESS FROM V$SESSION WHERE SID = :SID ) ";

            ht["SID"] = aSID;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
        }

        public static DataTable GetSessionInfo()
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;

            strCommand = @" SELECT sid, serial#, Audsid, UserName, Status, Server, OSuser, Machine, Terminal, Program,
                                   Type, SQL_HASH_Value, Module, Action, Client_Info, LogOn_Time, Inst_ID
                              FROM gv$session
                          ORDER BY UserName, Program    ";

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand);

            return dt;
        }

        public static DataTable GetOracleVersion()
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;

            strCommand = @" SELECT *
                              FROM V$VERSION
                             WHERE ROWNUM = 1   ";

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand);

            return dt;
        }

        public static DataTable GetUserList()
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;

            strCommand = @" SELECT USERNAME
                              FROM DBA_USERS
                             ORDER BY USERNAME  ";

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand);

            return dt;
        }

        public static DataTable GetTableColumns(string aUserID, string aTableName)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @" SELECT COLUMN_ID, COLUMN_NAME, DATA_TYPE||'('||DATA_LENGTH||')' AS DATA_TYPE, 
                                   DECODE(NULLABLE, 'N', 'NOT NULL') AS NULLABLE, DATA_DEFAULT AS DEFAULT_VALUE
                              FROM ALL_TAB_COLUMNS 
                             WHERE OWNER = :USERID 
                               AND TABLE_NAME = :TABLE_NAME
                          ORDER BY COLUMN_ID    ";

            ht["USERID"] = aUserID;
            ht["TABLE_NAME"] = aTableName;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
        }

        public static DataTable GetObjectList(string aUserID, string aObjectType)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @" SELECT OBJECT_NAME 
                              FROM ALL_OBJECTS 
                             WHERE OWNER = :USERID
                               AND OBJECT_TYPE = :OBJECT_TYPE
                             ORDER BY 1     ";

            ht["USERID"] = aUserID;
            ht["OBJECT_TYPE"] = aObjectType;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
        }
    }
}
