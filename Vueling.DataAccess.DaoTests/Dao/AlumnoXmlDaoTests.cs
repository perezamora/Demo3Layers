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
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        IAlumnoFormatoDao alumnoDao;
        ITypeFactory factory;

        [TestInitialize]
        public void testInit()
        {
            factory = new FileFactory();
            alumnoDao = factory.AddXml();
        }


        [DataRow(1, "Julia", "torrent", "2223", "01-03-1998")]
        [DataTestMethod]
        public void AddTest(int id, string name, string apellidos, string dni, string fechaNac)
        {
            log.Debug("Entrar metodo AddTest: ");
            // Convertir fecha nacimiento en formato DateTime
            var lfechaNac = fechaNac.Split('-');
            var FechaNac = new DateTime(Convert.ToInt32(lfechaNac[2]), Convert.ToInt32(lfechaNac[1]), Convert.ToInt32(lfechaNac[0]));

            // Creamos usuario de pruebas (asignamos Guid, fecha creacion y edad calculada)
            Alumno alumno = new Alumno(id, name, apellidos, dni, FechaNac);
            alumno.Guid = System.Guid.NewGuid().ToString();
            alumno.Edad = alumno.CalcularEdat();
            alumno.FechaCr = alumno.GetTimesTamp(DateTime.Now);

            // Añadimos variable entorno con el formato XML
            ConfigUtils.SetValorVarEnvironment("Xml");

            // Realizamos la llamada metodo para añadir elemento
            alumnoDao.Add(alumno);

            // Leemos fichero pruebas XML
            Alumno alumnoTest = LeerAlumnoXml();

            // Comaparamos el alumno insertado con el que hemos recuperado
            Console.WriteLine(alumno);
            Console.WriteLine(alumnoTest);
            Assert.AreEqual(alumno, alumnoTest);
            log.Debug("Salir metodo AddTest: ");
        }

        [TestCleanup]
        public void testClean()
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fullPath = path + "\\" + "alumnos.xml";

            File.Delete(fullPath);
        }

        public Alumno LeerAlumnoXml()
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var fullPath = path + "\\" + "alumnos.xml";

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