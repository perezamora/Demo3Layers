using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Vueling.Common.Logic.Util
{
    public static class LogUtil
    {
        private static readonly ILog _debugLogger;
  
        static LogUtil()
        {
            //logger names are mentioned in <log4net> section of config file
            _debugLogger = GetLogger(typeof(LogUtil));
        }


        private static ILog GetLogger(Type type)
        {
            ILog log = LogManager.GetLogger(type);
            return log;
        }

        public static void WriteDebugLog(string message)
        {
            Console.WriteLine(message);
            _debugLogger.DebugFormat(message);
        }
    }
}
