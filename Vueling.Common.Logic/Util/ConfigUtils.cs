using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using log4net;
using System.Reflection;

namespace Vueling.Common.Logic.Util
{
    public static class ConfigUtils
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static ConfigUtils() { }

        public static string GetValorVarEnvironment()
        {
            log.Debug("Entrar metodo GetValorVarEnvironment: ");
            try
            {
                var variable = (Environment.GetEnvironmentVariable("Formato") == null || Environment.GetEnvironmentVariable("Formato") == "")
                    ? "Txt" : Environment.GetEnvironmentVariable("Formato", EnvironmentVariableTarget.User);
                log.Debug("Valor variable entorno formato: " + variable);
                return variable;
            }
            catch (Exception e)
            {
                log.Error("Catch GetValorVarEnvironment: " + e);
                throw;
            }

        }

        public static void SetValorVarEnvironment(string format)
        {
            log.Debug("Entrar metodo SetValorVarEnvironment: ");
            try
            {
                Environment.SetEnvironmentVariable("Formato", format, EnvironmentVariableTarget.User);
            }
            catch (Exception e)
            {
                log.Error("Catch SetValorVarEnvironment: " + e);
                throw;
            }
        }
    }
}
