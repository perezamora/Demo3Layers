using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net;
using Vueling.Common.Logic.Util;

namespace Vueling.Business.Logic.Tests
{

    [TestClass()]
    public class AlumnoBLTests
    {
        private ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly AlumnoBL alumnoBL = new AlumnoBL();

        [DataRow("01-03-1998", 20)]
        [DataRow("01-03-1978", 40)]
        [DataTestMethod]
        public void CalcularEdatTest(string fechaNac, int edad)
        {
            log.Debug(string.Format("Entrar metodo CalcularEdatTest: Fecha Nacimiento: {0} edad: {1}", fechaNac, edad ));
            var edadTest = alumnoBL.CalcularEdat(Convert.ToDateTime(fechaNac));
            Assert.IsTrue(edadTest == edad);
        }
    }
}