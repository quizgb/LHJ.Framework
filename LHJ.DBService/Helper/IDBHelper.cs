using System;
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

        Boolean Open(string DataSource, string UserID, string Password);

        void Close();

        void BeginTrans();

        bool CommitTrans();

        bool RollbackTrans();

        DataTable ExecuteQuery(string Query);

        DataTable ExecuteQuery(string Query, List<ParamInfo> param);

        int ExecuteNonQuery(string Query);

        int ExecuteNonQuery(string Query, List<ParamInfo> param);
    }
}
