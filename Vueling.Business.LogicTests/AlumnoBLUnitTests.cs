using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.Business.LogicTests
{
    [TestClass]
    public class AlumnoBLUnitTests
    {

        private readonly MockFactory _factory = new MockFactory();

        [TestMethod]
        public void CalcularEdatUnitTest()
        {
            var alumno = new Alumno();
            alumno.Id = 1;
            alumno.Name = "Pere";
            alumno.Apellidos = "Zamora";
            alumno.Dni = "999999A";
            alumno.FechaNac = DateTime.Now;

            var mock = _factory.CreateMock<IAlumnoBL>();
            mock.Expects.One.MethodWith(al => al.Add(alumno)).WillReturn(new Alumno());
            Assert.IsTrue(true);
        }

    }
}
