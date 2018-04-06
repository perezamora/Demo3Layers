using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAccess.DaoTests
{
    [TestClass()]
    public static class LogginSetup
    {
        [AssemblyInitialize]
        public static void Configure(TestContext tc)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            
            ILog LOG = LogManager.GetLogger(typeof(LogginSetup));
            LOG.Debug("Log4net initialized for tests");
        }
    }
}
