using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;

namespace Vueling.Common.Logic.Util
{
    public static class ConfigUtils
    {
        private static ILogger log = CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public static object ConfigurationManager { get; private set; }

        static ConfigUtils() { }

        public static string GetValorVarEnvironment(string envVar )
        {
            log.Debug("Entrar metodo GetValorVarEnvironment: ");
            try
            {
                return Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.User);
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public static void SetValorVarEnvironment(string envVar, string envContent)
        {
            log.Debug("Entrar metodo SetValorVarEnvironment: ");
            try
            {
                Environment.SetEnvironmentVariable(envVar, envContent, EnvironmentVariableTarget.User);
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public static ILogger CreateInstanceClassLog(Type typeDeclaring)
        {
            var variable = Environment.GetEnvironmentVariable(Resources.ConfigRes.typelog, EnvironmentVariableTarget.User);
            var key = System.Configuration.ConfigurationManager.AppSettings[variable];

            Type t = Assembly.GetExecutingAssembly().GetType(key);

            object[] mParam = new object[] { typeDeclaring };
            return (ILogger)Activator.CreateInstance(t,mParam);
        }
    }
}
