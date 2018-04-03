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
            _debugLogger = GetLogger(typeof(LogUtil));
        }


        public static ILog GetLogger(Type type)
        {
            ILog log = LogManager.GetLogger(type);
            return log;
        }

        public static void WriteDebugLog(string message)
        {
            _debugLogger.DebugFormat(message);
        }

        public static void WriteInfoLog(string message)
        {
            _debugLogger.InfoFormat(message);
        }
    }
}
