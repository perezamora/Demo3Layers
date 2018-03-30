using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Util
{
    public static class LogUtil
    {
        private static readonly ILog _debugLogger;

        static LogUtil()
        {
            //logger names are mentioned in <log4net> section of config file
            _debugLogger = GetLogger("MyApplicationDebugLog");
        }


        private static ILog GetLogger(string logName)
        {
            ILog log = LogManager.GetLogger(logName);
            return log;
        }

        public static void WriteDebugLog(string message)
        {
            Console.WriteLine(message);
            _debugLogger.DebugFormat(message);
        }
    }
}
