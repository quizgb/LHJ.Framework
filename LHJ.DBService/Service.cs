using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Collections;

namespace LHJ.DBService
{
    /// <summary>
    /// System.Data.OracleClient를 사용하여 만든 Service Class
    /// </summary>
    public class Service
    {
        #region Private Variables
        private string mDataSource = string.Empty;
        private string mUserID = string.Empty;
        private string mPassword = string.Empty;
        private OracleConnection mOraConn = new OracleConnection();
        private OracleTransaction mTransaction = null;

        #endregion

        #region Properties
        public string DataSource
        {
            get { return mDataSource; }
            set { mDataSource = value; }
        }

        public string UserID
        {
            get { return mUserID; }
            set { mUserID = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public string ConnectionString
        {
            get { return mOraConn.ConnectionString; }
        }

        /// <summary>
        /// Database의 연결 상태를 보여준다.
        /// </summary>
        public ConnectionState State
        {
            get { return mOraConn.State; }
        }

        /// <summary>
        /// Database Version 값을 보여준다.
        /// </summary>
        public string ServerVersion
        {
            get { return mOraConn.ServerVersion; }
        }

        /// <summary>
        /// 현재 진행중인 Trascation을 표시한다.
        /// 아니면 null
        /// </summary>
        public OracleTransaction Transcation
        {
            get { return mTransaction; }
        }
        #endregion

        #region Constructor, Destructor

        #endregion

        #region Public Methods

        public bool Connect()
        {
            return Connect(this.mDataSource, this.mUserID, this.mPassword);
        }

        public bool Connect(string aDataSource, string aUserID, string aPassword)
        {
            this.mDataSource = aDataSource;
            this.mUserID = aUserID;
            this.mPassword = aPassword;

            if (string.IsNullOrEmpty(this.mDataSource) || string.IsNullOrEmpty(this.mUserID) || string.IsNullOrEmpty(this.mPassword))
            {
                return false;
            }

            try
            {
                if (this.mOraConn.State.Equals(ConnectionState.Closed))
                {
                    this.mOraConn.ConnectionString = string.Format("Data Source={0};Persist Security Info=True;User ID={1};Password={2}", this.mDataSource, this.mUserID, this.mPassword);
                    this.mOraConn.Open();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }

            return this.mOraConn.State.Equals(ConnectionState.Open) ? true : false;
        }

        public void Close()
        {
            try
            {
                this.mOraConn.Close();
                this.mOraConn.Dispose();
            }
            catch
            {

            }
        }

        #region transcation
        public void BeginTransaction()
        {
            this.mTransaction = this.mOraConn.BeginTransaction();
        }

        public bool CommitTransaction()
        {
            try
            {
                this.mTransaction.Commit();
                this.mTransaction = null;

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                return false;
            }
        }

        public bool RollbackTransaction()
        {
            try
            {
                this.mTransaction.Rollback();
                this.mTransaction = null;

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

        public DataSet ExecuteDataSet(string aQuery)
        {
            return this.ExecuteDataSet(aQuery, 0, 0, null, null);
        }

        public DataSet ExecuteDataSet(string aQuery, List<DBCmdParameter> aParam)
        {
            return this.ExecuteDataSet(aQuery, 0, 0, null, aParam);
        }

        public DataSet ExecuteDataSet(string aQuery, int aStartIndex, int aMaxIndex, string aSrcTable, List<DBCmdParameter> aParam)
        {
            if (this.mTransaction == null)
            {
                this.Connect();
            }

            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(aQuery, this.mOraConn);

            if (mTransaction != null)
            {
                cmd.Transaction = this.mTransaction;
            }

            if (aParam != null)
            {
                foreach (DBCmdParameter p in aParam)
                {
                    cmd.Parameters.AddWithValue(p.ParameterName, p.Value);
                }
            }

            try
            {
                da.SelectCommand = cmd;

                if (aStartIndex.Equals(0) && aMaxIndex.Equals(0))
                {
                    da.Fill(ds);
                }
                else
                {
                    da.Fill(ds, aStartIndex, aMaxIndex, aSrcTable);
                }

                return ds;
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, aQuery, aParam);
                return null;
            }
        }

        public DataTable ExecuteDataTable(string aQuery)
        {
            if (this.mTransaction == null)
            {
                this.Connect();
            }

            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(aQuery, this.mOraConn);

            if (mTransaction != null)
            {
                cmd.Transaction = this.mTransaction;
            }

            try
            {
                da.SelectCommand = cmd;
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorMessage(ex, aQuery);
                return null;
            }
        }

        public DataTable ExecuteDataTable(string aQuery, List<DBCmdParameter> aParam)
        {
            if (this.mTransaction == null)
            {
                this.Connect();
            }

            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(aQuery, this.mOraConn);

            if (mTransaction != null)
            {
                cmd.Transaction = this.mTransaction;
            }

            if (aParam != null)
            {
                foreach (DBCmdParameter p in aParam)
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
                ErrorMessage(ex, aQuery, aParam);
                return null;
            }
        }

        public DataTable ExecuteDataTable(string aQuery, Hashtable aParam)
        {
            if (this.mTransaction == null)
            {
                this.Connect();
            }

            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            OracleCommand cmd = new OracleCommand(aQuery, this.mOraConn);

            if (mTransaction != null)
            {
                cmd.Transaction = this.mTransaction;
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


        public OracleDataReader ExecuteReader(string aQuery)
        {
            return this.ExecuteReader(aQuery, null);
        }

        public OracleDataReader ExecuteReader(string aQuery, List<DBCmdParameter> aParam)
        {
            if (this.mTransaction == null)
            {
                this.Connect();
            }

            OracleCommand cmd = new OracleCommand(aQuery, this.mOraConn);

            if (this.mTransaction != null)
            {
                cmd.Transaction = this.mTransaction;
            }

            if (aParam != null)
            {
                foreach (DBCmdParameter p in aParam)
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
                ErrorMessage(ex, aQuery, aParam);
                return null;
            }
        }
        #endregion

        #region ExecuteScalar

        public object ExecuteScalar(string aQuery)
        {
            return ExecuteScalar(aQuery, null);
        }

        public object ExecuteScalar(string aQuery, List<DBCmdParameter> aParam)
        {
            OracleCommand cmd = new OracleCommand(aQuery, this.mOraConn);

            if (aParam != null)
            {
                foreach (DBCmdParameter p in aParam)
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
                ErrorMessage(ex, aQuery, aParam);
                return null;
            }
        }
        #endregion

        #region ExecuteNonQuery
        public int ExecuteNonQuery(string aQuery)
        {
            return ExecuteNonQuery(aQuery, null);
        }

        public int ExecuteNonQuery(string aQuery, List<DBCmdParameter> aParam)
        {
            int affected = -1;
            OracleCommand cmd = new OracleCommand(aQuery, this.mOraConn);

            if (this.mTransaction != null)
            {
                cmd.Transaction = this.mTransaction;
            }

            if (aParam != null)
            {
                foreach (DBCmdParameter p in aParam)
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
                ErrorMessage(ex, aQuery, aParam);
                return -1;
            }

            return affected;

        }
        #endregion

        #region ExecutePLSQL
        public int ExecutePLSQL(string aProcName, List<DBCmdParameter> aParam)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.CommandText = aProcName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = mOraConn;

            if (aParam != null)
            {
                foreach (DBCmdParameter p in aParam)
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
                ErrorMessage(ex, "Procedure " + aProcName, aParam);
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
            ErrorMessage(ex, Query, null);
        }

        private void ErrorMessage(Exception ex, string Query, Object aParam)
        {
            frmErrorMsg frm = new frmErrorMsg();
            frm.ex = ex;
            frm.Query = Query;
            frm.Param = aParam;

            frm.ShowDialog();
        }

        private string paramString(List<DBCmdParameter> param)
        {
            StringBuilder str = new StringBuilder("");

            if (param == null)
            {
                return "";
            }
            else
            {
                foreach (DBCmdParameter p in param)
                {
                    str.AppendLine(string.Format("{0} : {1}", p.ParameterName, p.Value));
                }

                return str.ToString();
            }
        }
        #endregion
    }

    public sealed class DBCmdParameter
    {
        OracleType mType;
        int mSize;
        string mParameterName;
        object mValue;

        public DBCmdParameter(string aParameterName, object aValue)
        {
            this.mParameterName = aParameterName;
            this.mValue = aValue;
        }

        private DBCmdParameter(string aParameterName, OracleType aType, int aSize, object aValue)
        {
            this.mType = aType;
            this.mSize = aSize;
            this.mParameterName = aParameterName;
            this.mValue = aValue;
        }

        public string ParameterName
        {
            get { return this.mParameterName; }
        }

        public object Value
        {
            get { return this.mValue; }
        }

        private OracleType DBType
        {
            get { return this.mType; }
        }

        private int Size
        {
            get { return this.mSize; }
        }
    }
}
