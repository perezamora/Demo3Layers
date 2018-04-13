using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAcces.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using log4net;
using System.Reflection;

namespace Vueling.DataAcces.Dao.Dao.Tests
{
    [TestClass()]
    public class AlumnoXmlDaoTests
    {
        private readonly ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly string fullPath = path + "\\" + "alumnos.xml";
        IAlumnoFormatoDao<Alumno> alumnoDao;
        ITypeFactory<Alumno> factory;

        [TestInitialize]
        public void testInit()
        {
            if (File.Exists(fullPath)) File.Delete(fullPath);
            ConfigUtils.SetValorVarEnvironment("Formato", "Xml");
            factory = new FileFactory<Alumno>();
            alumnoDao = factory.TypeXml();
        }

        [TestCleanup]
        public void testClean()
        {
            File.Delete(fullPath);
        }


        [DataRow(1, "Julia", "torrent", "2223", "01-03-1998", "20")]
        [DataTestMethod]
        public void AddTest(int id, string name, string apellidos, string dni, string fechaNac, string edad)
        {
            log.Debug("Entrar metodo AddTest: ");

            var lfechaNac = fechaNac.Split('-');
            var FechaNac = new DateTime(Convert.ToInt32(lfechaNac[2]), Convert.ToInt32(lfechaNac[1]), Convert.ToInt32(lfechaNac[0]));

            Alumno alumno = new Alumno(id, name, apellidos, dni, FechaNac, Convert.ToInt32(edad), DateTime.Now.ToString("yyyyMMddHHmmssffff"));
            alumno.Guid = System.Guid.NewGuid().ToString();

            alumnoDao.Add(alumno);
            Alumno alumnoTest = LeerAlumnoXml();

            Assert.AreEqual(alumno, alumnoTest);
            log.Debug("Salir metodo AddTest: ");
        }

        public Alumno LeerAlumnoXml()
        {
            if (File.Exists(fullPath))
            {
                List<Alumno> alumnos;
                XmlSerializer xSeriz = new XmlSerializer(typeof(List<Alumno>));
                using (StreamReader r = new StreamReader(fullPath))
                {
                    String xml = r.ReadToEnd();
                    StringReader stringReader = new StringReader(xml);
                    alumnos = (List<Alumno>)xSeriz.Deserialize(stringReader);
                }
                return alumnos[0];
            }
            else
            {
                return new Alumno();
            }
        }
    }
}