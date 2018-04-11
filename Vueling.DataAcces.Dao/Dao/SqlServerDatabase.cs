using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAcces.Dao.Dao
{
    public class SqlServerDatabase : IDatabase
    {
        public IDbConnection CreateOpenConnection()
        {
            throw new NotImplementedException();
        }
    }
}
