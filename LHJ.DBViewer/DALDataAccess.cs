using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LHJ.DBService;

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

            dt = DBHelper.ExecuteDataTable(strCommand);

            return dt;
        }

        public static DataTable GetUserList()
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;

            strCommand = @" SELECT USERNAME
                              FROM DBA_USERS
                             ORDER BY USERNAME  ";

            dt = DBHelper.ExecuteDataTable(strCommand);

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

            dt = DBHelper.ExecuteDataTable(strCommand, ht);

            return dt;
        }
    }
}
