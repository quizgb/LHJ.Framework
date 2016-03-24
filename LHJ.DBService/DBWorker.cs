using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LHJ.DBService
{
    public class DBWorker
    {
        private string m_DataSource = string.Empty;
        private string m_UserID = string.Empty;
        private string m_Password = string.Empty;
        private IDBHelper m_DBHelper = null;

        public DBWorker()
        {
            m_DBHelper = new LHJ.DBService.Helper.Oracle_OracleClient.clsOraDb();
        }

        public string GetDataSource()
        {
            return m_DBHelper.GetDataSource();
        }

        public string GetUserID()
        {
            return m_DBHelper.GetUserID();
        }

        public string GetPassWord()
        {
            return m_DBHelper.GetPassWord();
        }

        public ConnectionState GetConnState()
        {
            return m_DBHelper.GetConnState();
        }

        public Boolean Open(string aDataSource, string aUserID, string aPassWord)
        {
            this.m_DataSource = aDataSource;
            this.m_UserID = aUserID;
            this.m_Password = aPassWord;
            bool state = false;

            state = m_DBHelper.Open(aDataSource, aUserID, aPassWord);

            DataTable dtCharSet = this.ExecuteDataTable(@"SELECT VALUE FROM NLS_DATABASE_PARAMETERS WHERE PARAMETER = 'NLS_CHARACTERSET'");

            if (dtCharSet.Rows.Count > 0)
            {
                if (dtCharSet.Rows[0][0].ToString().Equals("US7ASCII"))
                {
                    m_DBHelper.Close();
                    m_DBHelper = new LHJ.DBService.Helper.Oracle_OleDb.clsOleDb();
                    state = m_DBHelper.Open(aDataSource, aUserID, aPassWord);
                }
                else
                {
                }
            }
            else
            {
            }

            return state;
        }

        public void Close()
        {
            m_DBHelper.Close();
        }

        public void BeginTrans()
        {
            m_DBHelper.BeginTrans();
        }

        public bool CommitTrans()
        {
            return m_DBHelper.CommitTrans();
        }

        public bool RollbackTrans()
        {
            return m_DBHelper.RollbackTrans();
        }

        public DataSet ExecuteDataSet(string Query, int aStartIndex, int aMaxIndex, string aSrcTable, List<ParamInfo> param)
        {
            return m_DBHelper.ExecuteDataSet(Query, aStartIndex, aMaxIndex, aSrcTable, param);
        }

        public DataTable ExecuteDataTable(string Query)
        {
            return m_DBHelper.ExecuteDataTable(Query);
        }

        public DataTable ExecuteDataTable(string Query, List<ParamInfo> param)
        {
            return m_DBHelper.ExecuteDataTable(Query, param);
        }

        public DataTable ExecuteDataTable(string Query, Hashtable ht)
        {
            return m_DBHelper.ExecuteDataTable(Query, ht);
        }

        public int ExecuteNonQuery(string Query)
        {
            return m_DBHelper.ExecuteNonQuery(Query, null);
        }

        public int ExecuteNonQuery(string Query, List<ParamInfo> param)
        {
            return m_DBHelper.ExecuteNonQuery(Query, param);
        }

        ~DBWorker()
        {
            //m_DBHelper.CloseSession();    // 하면 안됨. (Null Exception 발생함)
            m_DBHelper = null;
        }
    }
}
