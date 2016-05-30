using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace LHJ.DBService.Helper.Oracle_OracleClient
{
    public class clsOraDb : IDBHelper
    {
        #region Private Variables
        private string m_DataSource = string.Empty;
        private string m_UserID = string.Empty;
        private string m_Password = string.Empty;
        private OracleConnection m_OraCn = new OracleConnection();
        private OracleTransaction m_trans = null;

        #endregion

        #region Properties
        public string ConnectionString
        {
            get { return m_OraCn.ConnectionString; }
        }

        /// <summary>
        /// Database Version 값을 보여준다.
        /// </summary>
        public string ServerVersion
        {
            get { return m_OraCn.ServerVersion; }
        }

        /// <summary>
        /// 현재 진행중인 Trascation을 표시한다.
        /// 아니면 null
        /// </summary>
        public OracleTransaction Transcation
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
            return this.m_OraCn.State;
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

            return m_OraCn.State == ConnectionState.Open;
        }

        public void Connect()
        {
            try
            {
                if (m_OraCn.State == ConnectionState.Closed)
                {
                    m_OraCn.ConnectionString = string.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2}", m_DataSource, m_UserID, m_Password);

                    m_OraCn.Open();
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
                m_OraCn.Close();
                m_OraCn.Dispose();
            }
            catch
            {

            }
        }

        #region transcation
        public void BeginTrans()
        {
            m_trans = m_OraCn.BeginTransaction();
        }

        public bool CommitTrans()
        {
            try
            {
                if (m_OraCn.State == ConnectionState.Open && m_trans != null)
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
                if (m_OraCn.State == ConnectionState.Open && m_trans != null)
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

        public DataSet ExecuteDataSet(string Query, int aStartIndex, int aMaxIndex, string aSrcTable, List<ParamInfo> param)
        {
            if (m_trans == null)
                Connect();

            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(Query, m_OraCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                foreach (ParamInfo p in param)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
                da.SelectCommand = cmd;
                da.Fill(ds,aStartIndex, aMaxIndex, aSrcTable);
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

            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(Query, m_OraCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                foreach (ParamInfo p in param)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
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

        public DataTable ExecuteDataTable(string aQuery, Hashtable aParam)
        {
            if (this.m_trans == null)
            {
                this.Connect();
            }

            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(aQuery, this.m_OraCn);

            if (m_trans != null)
            {
                cmd.Transaction = this.m_trans;
            }

            if (aParam != null)
            {
                foreach (string paramName in aParam.Keys)
                {
                    cmd.Parameters.AddWithValue(paramName, aParam[paramName]);
                }
            }

            try
            {
                da.SelectCommand = cmd;
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, aQuery, aParam);
                return null;
            }
        }

        public DataTable ExecuteDataTable(string Query, int aStartIndex, int aMaxIndex, string aSrcTable, List<ParamInfo> param)
        {
            if (m_trans == null)
                Connect();

            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(Query, m_OraCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                foreach (ParamInfo p in param)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
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

        public OracleDataReader ExecuteReader(string Query)
        {
            return ExecuteReader(Query, null);
        }

        public OracleDataReader ExecuteReader(string Query, List<ParamInfo> param)
        {
            if (m_trans == null)
                Connect();

            OracleCommand cmd = new OracleCommand(Query, m_OraCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                foreach (ParamInfo p in param)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, Query, param);
                return null;
            }
        }
        #endregion

        #region ExecuteScalar

        public object ExecuteScalar(string Query)
        {
            return ExecuteScalar(Query, null);
        }

        public object ExecuteScalar(string Query, List<ParamInfo> param)
        {
            OracleCommand cmd = new OracleCommand(Query, m_OraCn);

            if (param != null)
            {
                foreach (ParamInfo p in param)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
                return cmd.ExecuteScalar();
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
            OracleCommand cmd = new OracleCommand(Query, m_OraCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (param != null)
            {
                foreach (ParamInfo p in param)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
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

        public int ExecuteNonQuery(string Query, Hashtable aParam)
        {
            int affected = -1;
            OracleCommand cmd = new OracleCommand(Query, m_OraCn);

            if (m_trans != null)
                cmd.Transaction = m_trans;

            if (aParam != null)
            {
                foreach (string paramName in aParam.Keys)
                {
                    cmd.Parameters.AddWithValue(paramName, aParam[paramName]);
                }
            }

            try
            {
                affected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, Query, aParam);
                return -1;
            }

            return affected;

        }
        #endregion

        #region ExecutePLSQL
        public int ExecutePLSQL(string ProcName, List<ParamInfo> param)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.CommandText = ProcName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = m_OraCn;

            if (param != null)
            {
                foreach (ParamInfo p in param)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
                DataSet ds = new DataSet();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, "Procedure " + ProcName, param);
                return -1;
            }
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

        private string paramString(List<ParamInfo> param)
        {
            StringBuilder str = new StringBuilder("");

            if (param == null)
            {
                return "";
            }
            else
            {
                foreach (ParamInfo p in param)
                {
                    str.AppendLine(string.Format("{0} : {1}", p.ParameterName, p.Value));
                }
                return str.ToString();
            }
        }
        #endregion
    }
}
