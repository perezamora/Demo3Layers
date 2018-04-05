using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using System.IO;
using Vueling.Common.Logic.Util;
using log4net;
using System.Reflection;

namespace Vueling.DataAcces.Dao
{
    public class AlumnoJsonDao : IAlumnoFormatoDao
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Alumno Add(Alumno alumno)
        {
            log.Debug("Entrar metodo Add JSON: " + alumno.ToString());
            try
            {
                FileStream fs = FileUtils.Append(FileUtils.getPath());
                FileUtils.Escribir(fs, alumno.ToJson());
                return alumno;
            }
            catch (FileNotFoundException e)
            {
                log.Error("Catch Add JSON: " + e);
                throw;
            }
            catch (Exception e)
            {
                log.Error("Catch Add JSON: " + e);
                throw;
            }
        }

        public List<Alumno> GetAlumnos()
        {
            log.Debug("Entrar metodo GetAlumnos JSON: ");
            try
            {
                FileStream fs = FileUtils.Abrir(FileUtils.getPath());
                List<String> list = FileUtils.LeerAllFile(fs);

                List<Alumno> lalumnos = new List<Alumno>();
                foreach (String item in list)
                {
                    log.Debug("item leido : " + item);
                    lalumnos.Add(FileUtils.DeserializarJson<Alumno>(item));
                }

                return lalumnos;
            }
            catch (FileNotFoundException e)
            {
                log.Error("Catch GetAlumnos JSON: " + e);
                throw;
            }
            catch (Exception e)
            {
                log.Error("Catch GetAlumnos JSON: " + e);
                throw;
            }
        }
    }
}
