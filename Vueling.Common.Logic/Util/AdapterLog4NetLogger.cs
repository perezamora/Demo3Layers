using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Util
{
    public class AdapterLog4NetLogger : ILogger
    {
        private readonly ILog _log;

        public AdapterLog4NetLogger(Type typeDeclaring)
        {
            this._log = LogManager.GetLogger(typeDeclaring);
        }

        public void Debug(object message)
        {
            this._log.Debug(message);
        }

        public void Error(object message)
        {
            this._log.Error(message);
        }

        public void Fatal(object message)
        {
            this._log.Fatal(message);
        }

        public void Info(object message)
        {
            this._log.Info(message);
        }

        public void Warn(object message)
        {
            this.Warn(message);
        }
    }
}
