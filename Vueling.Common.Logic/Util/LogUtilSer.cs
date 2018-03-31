using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Vueling.Common.Logic.Util
{
    public static class LogUtilSer
    {

        private static string pathLog;

        static LogUtilSer()
        {
            pathLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Log.txt";
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.RollingFile(pathLog)
                        .CreateLogger();
        }

        public static void WriteDebugSerilog(string message)
        {
            Log.Logger.Debug(message);
        }

        public static void WriteInfoSerilog(string message)
        {
            Log.Logger.Information(message);
        }

    }
}
