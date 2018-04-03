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
            return (Environment.GetEnvironmentVariable("Formato") == null || Environment.GetEnvironmentVariable("Formato") == "")
                ? "Txt" : Environment.GetEnvironmentVariable("Formato",EnvironmentVariableTarget.User);
        }

        public static void SetValorVarEnvironment(string format)
        {
            log.Debug("Entrar metodo SetValorVarEnvironment: ");
            Environment.SetEnvironmentVariable("Formato", format, EnvironmentVariableTarget.User);
        }
    }
}
