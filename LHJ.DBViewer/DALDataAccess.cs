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

        public static DataTable GetTableIndexInfo(string aUserID, string aTableName)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @" SELECT a.index_name,
                                   min(decode(a.uniqueness,'UNIQUE', 'UNIQUE')) uniqueness, 
                                   min(decode(column_position,1,b.column_name)) col1,
                                   min(decode(column_position,2,b.column_name)) col2,
                                   min(decode(column_position,3,b.column_name)) col3,
                                   min(decode(column_position,4,b.column_name)) col4,
                                   min(decode(column_position,5,b.column_name)) col5,
                                   min(decode(column_position,6,b.column_name)) col6,
                                   min(decode(column_position,7,b.column_name)) col7,
                                   min(decode(column_position,8,b.column_name)) col8,
                                   min(decode(column_position,9,b.column_name)) col9
                              FROM all_indexes a, all_ind_columns b
                             where a.table_owner = :OWNER 
                               and a.table_name = :TABLE_NAME
                               and a.owner = b.index_owner
                               and a.index_name = b.index_name
                             group by a.index_name
                             order by a.index_name  ";

            ht["OWNER"] = aUserID;
            ht["TABLE_NAME"] = aTableName;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
        }

        public static DataTable GetIndexByTableName(string aUserID, string aTableName)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @" SELECT INDEX_NAME
                              FROM ALL_INDEXES
                             WHERE OWNER = :OWNER
                               AND TABLE_NAME = :TABLE_NAME
                          ORDER BY UNIQUENESS DESC, INDEX_NAME  ";

            ht["OWNER"] = aUserID;
            ht["TABLE_NAME"] = aTableName;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
        }

        public static DataTable GetObjectScript(string aUserID, string aObjectName)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @" SELECT dbms_metadata.get_ddl(object_type, object_name, owner) SCRIPT
                              FROM ALL_OBJECTS
                             WHERE OWNER = :USERID
                               AND OBJECT_NAME = :OBJECT_NAME   ";

            ht["USERID"] = aUserID;
            ht["OBJECT_NAME"] = aObjectName;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
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

        public static DataTable GetTableData(string aUserID, string aTableName)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;

            strCommand = string.Format(@"   SELECT *
                                              FROM {0}.{1} ", aUserID, aTableName);

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand);

            return dt;
        }

        public static DataTable GetTableColumns(string aUserID, string aTableName)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @"   SELECT A.COLUMN_NAME, A.COLUMN_ID AS ID,
                                     (SELECT X.POSITION
                                        FROM SYS.DBA_CONS_COLUMNS X
                                       WHERE X.TABLE_NAME = :TABLE_NAME
		                                 AND X.CONSTRAINT_NAME IN (SELECT CN.NAME
                                                            			FROM SYS.CDEF$ C, SYS.CON$ CN, SYS.OBJ$ O, SYS.USER$ U
                                                            		   WHERE  C.TYPE# = 2
                                                            			 AND  C.CON# = CN.CON#
                                                            			 AND  C.OBJ# = O.OBJ#
                                                            			 AND  O.OWNER# = U.USER#
                                                            			 AND  U.NAME = :USERID
                                                            			 AND  O.NAME = :TABLE_NAME)
                                         AND X.OWNER = :USERID
                                         AND X.COLUMN_NAME = A.COLUMN_NAME) AS PK,
                                     DECODE(NULLABLE, 'N', 'NOT NULL') AS NULLABLE,
                                     A.DATA_TYPE||
  		                             DECODE(A.DATA_PRECISION, NULL,
  		                             DECODE(A.DATA_TYPE, 'NUMBER', '', 'DATE', '', '('||
  		                             DECODE(A.DATA_TYPE, 'NUMBER', A.DATA_PRECISION||', '||A.DATA_SCALE, A.DATA_LENGTH)||')'), '('||
  		                             DECODE(A.DATA_TYPE, 'NUMBER', A.DATA_PRECISION||', '||A.DATA_SCALE, A.DATA_LENGTH)||')') AS DATA_TYPE, 
                                     A.DATA_DEFAULT AS DEFAULT_VALUE, A.NUM_DISTINCT
                                FROM ALL_TAB_COLUMNS A
                               WHERE A.OWNER = :USERID
                                 AND A.TABLE_NAME = :TABLE_NAME
                               ORDER BY A.COLUMN_ID ";

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

            strCommand = @" SELECT * 
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

        public static DataTable GetObjectListByObjectName(string aUserID, string aObjectName)
        {
            DataTable dt = new DataTable();
            string strCommand = string.Empty;
            Hashtable ht = new Hashtable();

            strCommand = @" SELECT * 
                              FROM ALL_OBJECTS 
                             WHERE OWNER = :USERID
                               AND OBJECT_NAME = :OBJECT_NAME
                             ORDER BY 1     ";

            ht["USERID"] = aUserID;
            ht["OBJECT_NAME"] = aObjectName;

            dt = Common.Comm.DBWorker.ExecuteDataTable(strCommand, ht);

            return dt;
        }
    }
}
