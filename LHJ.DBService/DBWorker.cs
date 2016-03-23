using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LHJ.DBService
{
    public class DBWorker
    {
        private string m_SRC = string.Empty;
        private string m_ID = string.Empty;
        private string m_PW = string.Empty;

        private Common.Definition.ConstValue.Def_DatabaseType m_DBType = Common.Definition.ConstValue.Def_DatabaseType.Oracle_OracleClient;
        private IDBHelper m_DBHelper = null;

        public DBWorker()
    : this(Common.Definition.ConstValue.Def_DatabaseType.Oracle_OracleClient)
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

        public Boolean Open(string DataSource, string UserID, string Password)
        {
            return m_DBHelper.Open(DataSource, UserID, Password);
        }

        ~DBWorker()
        {
            //m_DBHelper.CloseSession();    // 하면 안됨. (Null Exception 발생함)
            m_DBHelper = null;
        }
    }
}
