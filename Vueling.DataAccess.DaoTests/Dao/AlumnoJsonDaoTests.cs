using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAcces.Dao.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;
using System.IO;
using Newtonsoft.Json;
using Vueling.Common.Logic.Util;
using log4net;
using System.Reflection;

namespace Vueling.DataAcces.Dao.Tests
{
    [TestClass()]
    public class AlumnoJsonDaoTests
    {
        private static readonly AdapterLog4NetLogger log = new AdapterLog4NetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly string fullPath = path + "\\" + "alumnos.json";
        IAlumnoFormatoDao<Alumno> alumnoDao;
        ITypeFactory<Alumno> factory;

        [TestInitialize]
        public void testInit()
        {
            if (File.Exists(fullPath)) File.Delete(fullPath);
            ConfigUtils.SetValorVarEnvironment("Json");
            factory = new FileFactory<Alumno>();
            alumnoDao = factory.TypeJson();
        }

        [TestCleanup]
        public void testClean()
        {
            File.Delete(fullPath);
        }

        [DataRow(1, "pere", "zamora", "3333", "01-03-1998","20")]
        [DataTestMethod]
        public void AddTest(int id, string name, string apellidos, string dni, string fechaNac, string edad)
        {
            log.Debug("Entrar metodo AddTest: ");

            var lfechaNac = fechaNac.Split('-');
            var FechaNac = new DateTime(Convert.ToInt32(lfechaNac[2]), Convert.ToInt32(lfechaNac[1]), Convert.ToInt32(lfechaNac[0]));

            Alumno alumno = new Alumno(id, name, apellidos, dni, FechaNac, Convert.ToInt32(edad), DateTime.Now.ToString("yyyyMMddHHmmssffff"));
            alumno.Guid = System.Guid.NewGuid().ToString();

            alumnoDao.Add(alumno);
            Alumno alumnoTest = LeerAlumnoJson();

            Console.WriteLine(alumno);
            Console.WriteLine(alumnoTest);
            Assert.IsTrue(alumno.Equals(alumnoTest));
            log.Debug("Salir metodo AddTest: ");
        }

        public Alumno LeerAlumnoJson()
        {
            // Validar si el insert se ha realizado correctamente
            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
            using (StreamReader sw = new StreamReader(fs))
            {
                // Recuperamos los alumnos del fichero Json
                String json = sw.ReadToEnd();
                return JsonConvert.DeserializeObject<Alumno>(json);
            }
        }
    }
}