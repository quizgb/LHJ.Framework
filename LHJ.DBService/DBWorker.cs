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
        #region 1.Variable
        private static Program m_Pgm = new Program();
        private string m_DataSource = string.Empty;
        private string m_UserID = string.Empty;
        private string m_Password = string.Empty;
        private IDBHelper m_DBHelper = null;
        #endregion 1.Variable


        #region 2.Property

        #endregion 2.Property


        #region 3.Constructor
        public DBWorker()
        {
            m_DBHelper = new LHJ.DBService.Helper.Oracle_OracleClient.clsOraDb();
        }

        ~DBWorker()
        {
            //m_DBHelper.CloseSession();    // 하면 안됨. (Null Exception 발생함)
            m_DBHelper = null;
        }
        #endregion 3.Constructor


        #region 4.Override Method

        #endregion 4.Override Method


        #region 5.Set Initialize
        /// <summary>
        /// Set Initialize
        /// </summary>
        public void SetInitialize()
        {

        }
        #endregion 5.Set Initialize


        #region 6.Method
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

            if (state)
            {
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

        public bool IsOnTrans()
        {
            return m_DBHelper.IsOnTrans();
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

        public DataTable ExecuteDataTable(string Query, int aStartIndex, int aMaxIndex, string aSrcTable, List<ParamInfo> param)
        {
            return m_DBHelper.ExecuteDataTable(Query, aStartIndex, aMaxIndex, aSrcTable, param);
        }

        public int ExecuteNonQuery(string Query)
        {
            return m_DBHelper.ExecuteNonQuery(Query);
        }

        public int ExecuteNonQuery(string Query, List<ParamInfo> param)
        {
            return m_DBHelper.ExecuteNonQuery(Query, param);
        }

        public int ExecuteNonQuery(string Query, Hashtable ht)
        {
            return m_DBHelper.ExecuteNonQuery(Query, ht);
        }
        #endregion 6.Method


        #region 7.Event

        #endregion 7.Event
    }
}
