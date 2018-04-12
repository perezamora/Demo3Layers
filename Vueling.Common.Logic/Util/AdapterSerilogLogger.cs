using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Vueling.Common.Logic.Util
{
    public class AdapterSerilogLogger : ILogger
    {
        private static readonly string pathLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\LogSerilog.txt";
        private readonly Serilog.ILogger _logger;

        public AdapterSerilogLogger(Type typeDeclaring)
        {
            this._logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.RollingFile(pathLog)
                        .WriteTo.Console()
                        .CreateLogger();
        }

        public void Debug(object message)
        {
            this._logger.Debug((string)message);
        }

        public void Error(object message)
        {
            this._logger.Error((string)message);
        }

        public void Fatal(object message)
        {
            this._logger.Fatal((string)message);
        }

        public void Info(object message)
        {
            this._logger.Information((string)message);
        }

        public void Warn(object message)
        {
            this._logger.Warning((string)message);
        }
    }
}
