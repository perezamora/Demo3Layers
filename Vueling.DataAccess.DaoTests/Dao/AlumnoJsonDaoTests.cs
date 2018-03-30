using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAcces.Dao;
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

namespace Vueling.DataAcces.Dao.Tests
{

    [TestClass()]
    public class AlumnoJsonDaoTests
    {

        IAlumnoFormatoDao alumnoDao;
        ITypeFactory factory;

        [TestInitialize]
        public void testInit()
        {
            factory = new FileFactory();
            alumnoDao = factory.AddJson();
        }


        [DataRow(1, "pere", "zamora", "3333", "01-03-1998")]
        [DataTestMethod]
        public void AddTest(int id, string name, string apellidos, string dni, string fechaNac)
        {
            // Convertir fecha nacimiento en formato DateTime
            var lfechaNac = fechaNac.Split('-');
            var FechaNac = new DateTime(Convert.ToInt32(lfechaNac[2]), Convert.ToInt32(lfechaNac[1]), Convert.ToInt32(lfechaNac[0]));

            // Creamos usuario de pruebas (asignamos Guid, fecha creacion y edad calculada)
            Alumno alumno = new Alumno(id, name, apellidos, dni, FechaNac);
            alumno.Guid = System.Guid.NewGuid().ToString();
            alumno.Edad = alumno.CalcularEdat();
            alumno.FechaCr = alumno.GetTimesTamp(DateTime.Now);

            // Añadimos variable entorno con el formato JSON
            ConfigUtils.SetValorVarEnvironment("Json");

            // Realizamos la llamada metodo para añadir elemento
            alumnoDao.Add(alumno);

            // Leemos fichero pruebas JSON
            Alumno alumnoTest = LeerAlumnoJson();

            // Comaparamos el alumno insertado con el que hemos recuperado
            Console.WriteLine(alumno);
            Console.WriteLine(alumnoTest);
            Assert.IsTrue(alumno.Equals(alumnoTest));
        }

        [TestCleanup]
        public void testClean()
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var fullPath = path + "\\" + "alumnos.json";

            File.Delete(fullPath);
        }

        public Alumno LeerAlumnoJson()
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var fullPath = path + "\\" + "alumnos.json";

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