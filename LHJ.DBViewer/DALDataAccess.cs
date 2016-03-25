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
