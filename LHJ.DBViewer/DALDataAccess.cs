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
        public static int DeleteLock(string aSID_SERIAL)
        {
            string strCommand = string.Empty;
            strCommand = string.Format("Alter System Kill Session '{0}' immediate", aSID_SERIAL);

            return Common.Comm.DBWorker.ExecuteNonQuery(strCommand);
        }

        public static DataTable GetTableSpaceList()
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;

            strCommand = @"  SELECT TABLESPACE_NAME
                               FROM DBA_DATA_FILES

                               UNION ALL

                              SELECT TABLESPACE_NAME
                                FROM DBA_TEMP_FILES
                            ORDER BY TABLESPACE_NAME ";

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand);

            return dt;
        }

        public static DataTable GetTableSpaceInfo(string aTableSpaceName)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @"  SELECT MAX(D.FILE_NAME) FILE_NAME,
                                    MAX(D.FILE_ID) FILE_ID,
                                    ROUND((MAX(D.BYTES) - nvl(SUM(F.BYTES), 0)) / MAX(D.BYTES) * 100, 0) USAGE,
                                    ROUND(MAX(D.BYTES) / 1024 / 1024, 2)||'MB' TOTAL,
                                    ROUND((MAX(D.BYTES) - nvl(SUM(F.BYTES), 0)) / 1024 / 1024, 2)||'MB' USED,
                                    ROUND(NVL(SUM(F.BYTES), 0) / 1024 / 1024, 2)||'MB' FREE,
                                    MAX(D.AUTOEXTENSIBLE) AUTOEXTENSIBLE,
                                    MAX(D.STATUS) STATUS
                               FROM DBA_FREE_SPACE F, DBA_DATA_FILES D
                              WHERE F.TABLESPACE_NAME(+) = D.TABLESPACE_NAME
                                AND F.FILE_ID(+) = D.FILE_ID
                                AND D.TABLESPACE_NAME = :TABLESPACE_NAME  ";

            ht["TABLESPACE_NAME"] = aTableSpaceName;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
        }

        public static DataTable GetLockList()
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;

            strCommand = @"  SELECT /*+ rule */  DISTINCT c.SID, c.serial#, p.pid AS process, b.owner, b.object_name, 
                                    DECODE (a.TYPE, 'TM', 'Table Lock', 'TX', 'Row Lock', NULL ) AS lock_level, 
                                    c.status, 
                                    TO_CHAR (c.logon_time, 'yyyy/mm/dd hh24:mi:ss') AS logon_time, 
                                    TO_CHAR (t.start_date, 'yyyy/mm/dd hh24:mi:ss') AS start_time, 
                                    a.id2 AS num, c.osuser, c.terminal, c.program 
                              FROM gv$session c, 
                                   dba_objects b, 
                                   v$lock a, 
                                   v$locked_object l, 
                                   v$process p, 
                                   v$transaction t 
                             WHERE c.SID = a.SID 
                               AND a.id2 > 1 
                               AND b.object_id = l.object_id 
                               AND p.addr = c.paddr 
                               AND a.addr = t.addr 
                             ORDER BY start_time, id2  ";

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand);

            return dt;
        }

        public static DataTable GetSessionHashValue(string aSID)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @"  SELECT DECODE(sql_hash_value, 0, prev_hash_value, sql_hash_value) HASH
                               FROM v$session
                              WHERE SID = :SID  ";

            ht["SID"] = aSID;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
        }

        public static DataTable GetSessionSql(string aHashValue)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @"  SELECT SQL_TEXT 
                               FROM V$SQLTEXT_WITH_NEWLINES 
                              WHERE HASH_VALUE = TO_NUMBER(:HASH_VALUE) 
                              ORDER BY PIECE  ";

            ht["HASH_VALUE"] = aHashValue;

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

        public static DataTable GetObjectListByObjectName(string aUserID, string aObjectType, string aObjectName)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @" SELECT OBJECT_NAME 
                              FROM ALL_OBJECTS 
                             WHERE OWNER = :USERID
                               AND OBJECT_TYPE = :OBJECT_TYPE
                               AND OBJECT_NAME LIKE '%' || :OBJECT_NAME || '%'
                             ORDER BY 1     ";

            ht["USERID"] = aUserID;
            ht["OBJECT_TYPE"] = aObjectType;
            ht["OBJECT_NAME"] = aObjectName;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
        }
    }
}
