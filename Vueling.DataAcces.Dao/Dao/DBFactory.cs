using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAcces.Dao.Dao
{ 
    public class DBFactory
    {
        public IDatabase DBSqlServer()
        {
            return new SqlServerDatabase();
        }
    }
}
