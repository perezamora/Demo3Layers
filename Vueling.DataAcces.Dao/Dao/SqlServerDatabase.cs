using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Util;

namespace Vueling.DataAcces.Dao.Dao
{
    public class SqlServerDatabase : IDatabase
    {
        private ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public IDbConnection CreateOpenConnection()
        {
            try
            {
                IDbConnection connection = new SqlConnection();
                var connectionString = Properties.Settings.Default.cn;
                log.Debug(connectionString);
                connection.ConnectionString = connectionString;
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
          
        }

        public IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            try
            {
                IDbCommand comando = new SqlCommand();
                comando.Connection = connection;
                comando.CommandText = commandText;
                return comando;
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public void CloseConnection(IDbConnection connection)
        {
            connection.Close();
        }

        private string GetConnectionStringByName(string name)
        {
            string returnValue = null;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

    }
}
