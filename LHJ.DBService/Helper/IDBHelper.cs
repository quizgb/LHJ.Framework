using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LHJ.DBService
{
    interface IDBHelper
    {
        string GetDataSource();

        string GetUserID();

        string GetPassWord();

        ConnectionState GetConnState();

        Boolean Open(string DataSource, string UserID, string Password);

        void Close();

        void BeginTrans();

        bool CommitTrans();

        bool RollbackTrans();

        DataSet ExecuteDataSet(string Query, int aStartIndex, int aMaxIndex, string aSrcTable, List<ParamInfo> param);

        DataTable ExecuteDataTable(string Query);

        DataTable ExecuteDataTable(string Query, List<ParamInfo> param);

        DataTable ExecuteDataTable(string Query, Hashtable ht);

        int ExecuteNonQuery(string Query);

        int ExecuteNonQuery(string Query, List<ParamInfo> param);
    }
}
