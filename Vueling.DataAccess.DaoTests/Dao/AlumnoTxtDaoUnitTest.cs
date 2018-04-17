using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Common.Logic.Model;
using Vueling.DataAcces.Dao.Dao;

namespace Vueling.DataAccess.DaoTests.Dao
{
    [TestClass()]
    public class AlumnoTxtDaoUnitTest
    {

        private MockFactory _factory;
        private Mock<IAlumnoFormatoDao<Alumno>> mockTextDao;
        private Alumno alumno;

        [TestInitialize]
        public void TestInit()
        {
            _factory = new MockFactory();
            mockTextDao = _factory.CreateMock<IAlumnoFormatoDao<Alumno>>();
            alumno = new Alumno();
        }


        [TestCleanup]
        public void TestClean()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }

        [TestMethod]
        public void GetAlumnos_FormatoTxt_unitTest()
        {

            Alumno alumno1 = Load_Properties_Alumno(1, "Maria", "Pellicer", "999999a", "10-03-1978", "40");
            Alumno alumno2 = Load_Properties_Alumno(2, "Anna", "Pellicer", "999999a", "10-03-1980", "38");
            List<Alumno> alumnos = new List<Alumno> { alumno1, alumno2 };

            mockTextDao.Expects.One.Method(alumnoDaoInst => alumnoDaoInst.GetAll()).WillReturn(alumnos);

            Assert.AreEqual(alumnos, mockTextDao.MockObject.GetAll());
        }


        private Alumno Load_Properties_Alumno(int id, string name, string apellidos, string dni, string fechaNac, string edad)
        {
            Alumno alumnoTest = new Alumno();
            alumno.Guid = Guid.NewGuid().ToString();
            alumno.Id = id;
            alumno.Name = name;
            alumno.Apellidos = apellidos;
            alumno.Dni = dni;
            alumno.FechaNac = Convert.ToDateTime(fechaNac);
            alumno.Edad = Convert.ToInt32(edad);
            alumno.FechaCr = DateTime.Now.ToString();

            return alumnoTest;
        }

    }
}
