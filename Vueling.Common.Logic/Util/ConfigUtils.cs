using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Vueling.Common.Logic.Util
{
    public static class ConfigUtils
    {

        static ConfigUtils() { }

        public static string GetValorVarEnvironment()
        {
            return (Environment.GetEnvironmentVariable("Formato") == null || Environment.GetEnvironmentVariable("Formato") == "")
                ? "Txt" : Environment.GetEnvironmentVariable("Formato",EnvironmentVariableTarget.User);
        }

        public static void SetValorVarEnvironment(string format)
        {
            Environment.SetEnvironmentVariable("Formato", format, EnvironmentVariableTarget.User);
        }
    }
}
