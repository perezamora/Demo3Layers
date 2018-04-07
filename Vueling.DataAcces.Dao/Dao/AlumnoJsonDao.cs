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
    public class AlumnoJsonDao<T> : IAlumnoFormatoDao<T> where T : VuelingObject
    {
        private readonly AdapterLog4NetLogger log = new AdapterLog4NetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string path;

        public AlumnoJsonDao()
        {
            path = FileUtils.GetPath();
        }

        public T Add(T item)
        {
            log.Debug("Entrar metodo Add JSON: " + item.ToString());
            try
            {
                FileStream fs = FileUtils.Append(path);
                FileUtils.Escribir(fs, FileUtils.SerializarJson(item));
                return item;
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

        public List<T> GetAlumnos()
        {
            log.Debug("Entrar metodo GetAlumnos JSON: ");
            try
            {
                List<T> lalumnos = new List<T>();
                if (File.Exists(path))
                {
                    FileStream fs = FileUtils.Abrir(path);
                    List<String> list = FileUtils.LeerAllFile(fs);


                    foreach (String item in list)
                    {
                        log.Debug("item leido : " + item);
                        lalumnos.Add(FileUtils.DeserializarJson<T>(item));
                    }
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
