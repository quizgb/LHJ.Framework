using System;
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

        private Common.Definition.ConstValue.Def_DatabaseType m_DBType = Common.Definition.ConstValue.Def_DatabaseType.Oracle_OracleClient;
        private IDBHelper m_DBHelper = null;

        public DBWorker() : this(Common.Definition.ConstValue.Def_DatabaseType.Oracle_OracleClient)
        {

        }

        public DBWorker(Common.Definition.ConstValue.Def_DatabaseType DbType)
        {
            m_DBType = DbType;

            switch (m_DBType)
            {
                case Common.Definition.ConstValue.Def_DatabaseType.Oracle_OracleClient:
                    m_DBHelper = new LHJ.DBService.Helper.Oracle_OleDb.clsOleDb();
                    break;

                case Common.Definition.ConstValue.Def_DatabaseType.Oracle_OleDb:
                    m_DBHelper = new LHJ.DBService.Helper.Oracle_OracleClient.clsOraDb();
                    break;

                default:
                    break;
            }
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

        public Boolean Open(string aDataSource, string aUserID, string aPassWord)
        {
            this.m_DataSource = aDataSource;
            this.m_UserID = aUserID;
            this.m_Password = aPassWord;

            return m_DBHelper.Open(aDataSource, aUserID, aPassWord);
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

        public DataTable ExecuteQuery(string Query)
        {
            return m_DBHelper.ExecuteQuery(Query);
        }

        public DataTable ExecuteQuery(string Query, List<ParamInfo> param)
        {
            return m_DBHelper.ExecuteQuery(Query, param);
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
