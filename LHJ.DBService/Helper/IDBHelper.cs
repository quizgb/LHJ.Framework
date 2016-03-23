using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LHJ.DBService
{
    interface IDBHelper
    {
        Boolean Open(string DataSource, string UserID, string Password);
    }
}
