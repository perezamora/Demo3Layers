using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;
using System.IO;
using log4net;
using System.Reflection;

namespace Vueling.DataAcces.Dao
{
    public class AlumnoTxtDao : IAlumnoFormatoDao
    {
        private static readonly AdapterLog4NetLogger log = new AdapterLog4NetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Alumno Add(Alumno alumno)
        {
            log.Debug("Entrar metodo Add TXT: " + alumno.ToString());
            try
            {
                FileStream fs = FileUtils.Append(FileUtils.getPath());
                FileUtils.Escribir(fs, alumno.ToString());
                return alumno;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public List<Alumno> GetAlumnos()
        {
            log.Debug("Entrar metodo GetAlumnos: ");
            try
            {
                FileStream fs = FileUtils.Abrir(FileUtils.getPath());
                List<String> list = FileUtils.LeerAllFile(fs);

                List<Alumno> lalumnos = new List<Alumno>();
                foreach (String item in list)
                {
                    string[] fields = item.Split(';');
                    lalumnos.Add(new Alumno(int.Parse(fields[0]), fields[1], fields[2], fields[3], Convert.ToDateTime(fields[4]), Convert.ToInt32(fields[5]), fields[6], fields[7]));
                    log.Debug(item);
                }

                return lalumnos;
            }
            catch (FileNotFoundException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }
    }
}
