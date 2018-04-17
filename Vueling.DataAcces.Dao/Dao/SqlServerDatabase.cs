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
        private readonly ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public IDbConnection CreateOpenConnection()
        {
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                IDbConnection connection = new SqlConnection();
                var connectionString = Properties.Settings.Default.cn;
                log.Debug(connectionString);
                connection.ConnectionString = connectionString;
                connection.Open();
                return connection;
            }
            catch (SqlException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
          
        }

        public IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                IDbCommand comando = new SqlCommand();
                comando.Connection = connection;
                comando.CommandText = commandText;
                return comando;
            }
            catch (SqlException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public void CloseConnection(IDbConnection connection)
        {
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            connection.Close();
        }

        private string GetConnectionStringByName(string name)
        {
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            string returnValue = null;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        public void AddParameter(IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
    }
}
