using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace LHJ.DBService
{
    public static class DBHelper
    {
        #region Variables
        private static Service mService = new Service();
        private static bool mConnected = false;
        private static bool mShowErrorMessage = true;

        #endregion

        #region Properties
        public static bool ShowErrorMessage
        {
            set { mShowErrorMessage = value; }
            get { return mShowErrorMessage; }
        }

        public static ConnectionState State
        {
            get { return mService.State; }
        }

        public static string ServerVersion
        {
            get { return mService.ServerVersion; }
        }

        public static OracleTransaction Transcation
        {
            get { return mService.Transcation; }
        }

        public static string UserID
        {
            get { return mService.UserID; }
        }

        public static string DataSource
        {
            get { return mService.DataSource; }
        }

        #endregion

        #region Method


        public static bool Connect(string aUserId, string aPassword, string aDataSource)
        {
            mService.UserID = aUserId;
            mService.Password = aPassword;
            mService.DataSource = aDataSource;

            mConnected = mService.Connect();
            return mConnected;
        }

        public static void Close()
        {
            mService.Close();
        }

        public static void BeginTransaction()
        {
            mService.BeginTransaction();
        }

        public static bool CommitTransaction()
        {
            return mService.CommitTransaction();
        }

        public static bool RollbackTransaction()
        {
            return mService.RollbackTransaction();
        }

        public static object ExecuteScalar(string Query)
        {
            return mService.ExecuteScalar(Query);
        }

        public static object ExecuteScalar(string Query, List<DBCmdParameter> param)
        {
            return mService.ExecuteScalar(Query, param);
        }

        public static DataSet ExecuteDataSet(string Query)
        {
            return mService.ExecuteDataSet(Query);
        }

        public static DataSet ExecuteDataSet(string Query, List<DBCmdParameter> param)
        {
            return mService.ExecuteDataSet(Query, param);
        }

        public static DataSet ExecuteDataSet(string Query, int aStartIndex, int aMaxIndex, string aSrcTable, List<DBCmdParameter> param)
        {
            return mService.ExecuteDataSet(Query, aStartIndex, aMaxIndex, aSrcTable, param);
        }

        public static DataTable ExecuteDataTable(string Query)
        {
            return mService.ExecuteDataTable(Query);
        }

        public static DataTable ExecuteDataTable(string Query, Hashtable ht)
        {
            return mService.ExecuteDataTable(Query, ht);
        }

        public static DataTable ExecuteDataTable(string Query, List<DBCmdParameter> param)
        {
            return mService.ExecuteDataTable(Query, param);
        }

        public static OracleDataReader ExecuteReader(string Query)
        {
            return mService.ExecuteReader(Query);
        }

        public static OracleDataReader ExecuteReader(string Query, List<DBCmdParameter> param)
        {
            return mService.ExecuteReader(Query, param);
        }

        public static int ExecuteNonQuery(string Query)
        {
            return mService.ExecuteNonQuery(Query, null);
        }

        public static int ExecuteNonQuery(string Query, List<DBCmdParameter> param)
        {
            return mService.ExecuteNonQuery(Query, param);
        }

        public static int ExecutePLSQL(string cmd, List<DBCmdParameter> param)
        {
            return mService.ExecutePLSQL(cmd, param);
        }

        #endregion
    }

}