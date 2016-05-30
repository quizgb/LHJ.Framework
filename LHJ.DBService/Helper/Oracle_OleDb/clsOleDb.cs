using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace LHJ.DBService.Helper.Oracle_OleDb
{
    public class clsOleDb : IDBHelper
    {
        #region Private Variables
        private string m_DataSource = string.Empty;
        private string m_UserID = string.Empty;
        private string m_Password = string.Empty;
        private OleDbConnection m_OledbCn = new OleDbConnection();
        private OleDbTransaction m_trans = null;

        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return m_OledbCn.ConnectionString; }
        }

        /// <summary>
        /// Database Version 값을 보여준다.
        /// </summary>
        public string ServerVersion
        {
            get { return m_OledbCn.ServerVersion; }
        }

        /// <summary>
        /// 현재 진행중인 Trascation을 표시한다.
        /// 아니면 null
        /// </summary>
        public OleDbTransaction Transcation
        {
            get { return m_trans; }
        }
        #endregion

        #region Constructor, Destructor

        #endregion

        #region Public Methods

        public string GetDataSource()
        {
            return this.m_DataSource;
        }

        public string GetUserID()
        {
            return this.m_UserID;
        }

        public string GetPassWord()
        {
            return this.m_Password;
        }

        public ConnectionState GetConnState()
        {
            return this.m_OledbCn.State;
        }

        public Boolean Open()
        {
            return Open(m_DataSource, m_UserID, m_Password);
        }

        public Boolean Open(string DataSource, string UserID, string Password)
        {
            this.m_DataSource = DataSource;
            this.m_UserID = UserID;
            this.m_Password = Password;

            if (m_UserID == string.Empty)
                return false;

            Connect();

            return m_OledbCn.State == ConnectionState.Open;
        }

        public void Connect()
        {
            try
            {
                if (m_OledbCn.State == ConnectionState.Closed)
                {
                    m_OledbCn.ConnectionString = string.Format("Provider=MSDAORA;Data Source={0};Persist Security Info=True;User ID={1};Password={2}", m_DataSource, m_UserID, m_Password);

                    m_OledbCn.Open();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        public void Close()
        {
            try
            {
                m_OledbCn.Close();
                m_OledbCn.Dispose();
            }
            catch
            {

            }
        }

        #region transcation
        public void BeginTrans()
        {
            m_trans = m_OledbCn.BeginTransaction();
        }

        public bool CommitTrans()
        {
            try
            {
                if (m_OledbCn.State == ConnectionState.Open && m_trans != null)
                {
                    m_trans.Commit();
                    m_trans.Dispose();
                    m_trans = null;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                return false;
            }
        }

        public bool RollbackTrans()
        {
            try
            {
                if (m_OledbCn.State == ConnectionState.Open && m_trans != null)
                {
                    m_trans.Rollback();
                    m_trans.Dispose();
                    m_trans = null;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                return false;
            }
        }

        public bool IsOnTrans()
        {
            try
            {
                if (m_trans == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                return false;
            }
        }
        #endregion

        #region ExecuteQuery

        private OleDbCommand SetCmdParamter(OleDbCommand aCmd, List<ParamInfo> aParamList)
        {
            List<string> xParamList = new List<string>();
            Dictionary<string, object> ParamInfos = new Dictionary<string, object>();
            List<string> names = new List<string>();
            string tQuery = aCmd.CommandText;
            int idx = 0;
            List<int> idxLIst = new List<int>();

            foreach (ParamInfo p in aParamList)
            {
                xParamList.Add(p.ParameterName);
                ParamInfos.Add(p.ParameterName, p.Value);
            }

            // ?로 대체시 Key 역순으로 해야 replace문제가 안생긴다.
            xParamList.Sort();
            xParamList.Reverse();

            foreach (string str in xParamList)
            {
                idx = 0;

                tQuery = tQuery.Replace(":" + str, "?");

                do
                {
                    idx = aCmd.CommandText.IndexOf(":" + str, idx);

                    if (idx > 0)
                    {
                        if (!idxLIst.Contains(idx))
                        {
                            idxLIst.Add(idx);
                            names.Add(idx.ToString("000000") + ":" + str);
                        }
                    }
                } while (idx++ > 0);

                //aCmd.CommandText = aCmd.CommandText.Replace(":" + str, "?");
                //aCmd.CommandText = tQuery;
            }

            names.Sort();
            aCmd.CommandText = tQuery;

            foreach (string s in names)
            {
                string[] x = s.Split(':');
                aCmd.Parameters.AddWithValue(x[1] + "_" + x[0], ParamInfos[x[1]]);
            }

            //foreach (ParamInfo p in aParamList)
            //{
            //    aCmd.Parameters.AddWithValue("@" + p.ParameterName, p.Value);
            //}

            return aCmd;
        }

        private OleDbCommand SetCmdParamter(OleDbCommand aCmd, Hashtable aParamList)
        {
            List<string> xParamList = new List<string>();
            Dictionary<string, object> ParamInfos = new Dictionary<string, object>();
            List<string> names = new List<string>();
            string tQuery = aCmd.CommandText;
            int idx = 0;
            List<int> idxLIst = new List<int>();

            foreach (DictionaryEntry entry in aParamList)
            {
                xParamList.Add(entry.Key.ToString());
                ParamInfos.Add(entry.Key.ToString(), entry.Value);
            }

            // ?로 대체시 Key 역순으로 해야 replace문제가 안생긴다.
            xParamList.Sort();
            xParamList.Reverse();

            foreach (string str in xParamList)
            {
                idx = 0;

                tQuery = tQuery.Replace(":" + str, "?");

                do
                {
                    idx = aCmd.CommandText.IndexOf(":" + str, idx);

                    if (idx > 0)
                    {
                        if (!idxLIst.Contains(idx))
                        {
                            idxLIst.Add(idx);
                            names.Add(idx.ToString("000000") + ":" + str);
                        }
                    }
                } while (idx++ > 0);

                //aCmd.CommandText = aCmd.CommandText.Replace(":" + str, "?");
                //aCmd.CommandText = tQuery;
            }

            names.Sort();
            aCmd.CommandText = tQuery;

            foreach (string s in names)
            {
                string[] x = s.Split(':');
                aCmd.Parameters.AddWithValue(x[1] + "_" + x[0], ParamInfos[x[1]]);
            }

            //foreach (ParamInfo p in aParamList)
            //{
            //    aCmd.Parameters.AddWithValue("@" + p.ParameterName, p.Value);
            //}

            return aCmd;
        }

        public DataSet ExecuteDataSet(string Query, int aStartIndex, int aMaxIndex, string aSrcTable, List<ParamInfo> param)
        {
            if (m_trans == null)
                Connect();

            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand(Query, m_OledbCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                cmd = this.SetCmdParamter(cmd, param);
            }

            try
            {
                //cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds, aStartIndex, aMaxIndex, aSrcTable);
                return ds;
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, Query, param);
                return null;
            }
        }

        public DataTable ExecuteDataTable(string Query)
        {
            return ExecuteDataTable(Query, new List<ParamInfo>());
        }

        public DataTable ExecuteDataTable(string Query, List<ParamInfo> param)
        {
            if (m_trans == null)
                Connect();

            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand(Query, m_OledbCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                cmd = this.SetCmdParamter(cmd, param);
            }

            try
            {
                //cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, Query, param);
                return null;
            }
        }

        public DataTable ExecuteDataTable(string Query, Hashtable param)
        {
            if (m_trans == null)
                Connect();

            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand(Query, m_OledbCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                cmd = this.SetCmdParamter(cmd, param);
            }

            try
            {
                //cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, Query, param);
                return null;
            }
        }

        public DataTable ExecuteDataTable(string Query, int aStartIndex, int aMaxIndex, string aSrcTable, List<ParamInfo> param)
        {
            if (m_trans == null)
                Connect();

            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand(Query, m_OledbCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                cmd = this.SetCmdParamter(cmd, param);
            }

            try
            {
                //cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds, aStartIndex, aMaxIndex, aSrcTable);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, Query, param);
                return null;
            }
        }

        public DataTable ExecuteDataTable(string Query, int aStartIndex, int aMaxIndex, string aSrcTable, Hashtable param)
        {
            if (m_trans == null)
                Connect();

            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand(Query, m_OledbCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                cmd = this.SetCmdParamter(cmd, param);
            }

            try
            {
                //cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, Query, param);
                return null;
            }
        }

        #endregion

        #region ExecuteNonQuery
        public int ExecuteNonQuery(string Query)
        {
            return ExecuteNonQuery(Query, new List<ParamInfo>());
        }

        public int ExecuteNonQuery(string Query, List<ParamInfo> param)
        {
            int affected = -1;
            OleDbCommand cmd = new OleDbCommand(Query, m_OledbCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                cmd = this.SetCmdParamter(cmd, param);
            }

            try
            {
                affected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, Query, param);
                return -1;
            }

            return affected;

        }

        public int ExecuteNonQuery(string Query, Hashtable param)
        {
            int affected = -1;
            OleDbCommand cmd = new OleDbCommand(Query, m_OledbCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                cmd = this.SetCmdParamter(cmd, param);
            }

            try
            {
                affected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, Query, param);
                return -1;
            }

            return affected;

        }
        #endregion

        #endregion

        #region Private Methods
        private void ErrorMessage(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, "오류", System.Windows.Forms.MessageBoxButtons.OK);
        }

        private void ErrorMessage(Exception ex, string Query)
        {
            ErrorMessage(ex, Query, new List<ParamInfo>());
        }

        private void ErrorMessage(Exception ex, string Query, List<ParamInfo> param)
        {
            frmErrorMsg frm = new frmErrorMsg();
            frm.Ex = ex;
            frm.Query = Query;
            frm.Param = param;

            frm.ShowDialog();
        }

        private void ErrorMessage(Exception ex, string Query, Hashtable param)
        {
            frmErrorMsg frm = new frmErrorMsg();
            frm.Ex = ex;
            frm.Query = Query;
            frm.Param = param;

            frm.ShowDialog();
        }
        #endregion
    }
}
