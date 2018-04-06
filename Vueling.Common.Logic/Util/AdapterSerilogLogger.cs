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
        private static readonly string pathLog = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Log.txt";

        public AdapterSerilogLogger()
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.RollingFile(pathLog)
                        .WriteTo.Console()
                        .CreateLogger();
        }

        public void Debug(object message)
        {
            Log.Debug((string)message);
        }

        public void Error(object message)
        {
            Log.Error((string)message);
        }

        public void Fatal(object message)
        {
            Log.Fatal((string)message);
        }

        public void Info(object message)
        {
            Log.Information((string)message);
        }

        public void Warn(object message)
        {
            Log.Warning((string)message);
        }
    }
}
