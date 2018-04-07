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
    public class AlumnoTxtDao<T> : IAlumnoFormatoDao<T> where T : VuelingObject
    {
        private readonly AdapterLog4NetLogger log = new AdapterLog4NetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string path;

        public AlumnoTxtDao()
        {
            path = FileUtils.GetPath();
        }

        #region Metodos
        public T Add(T item)
        {
            log.Debug("Entrar metodo Add TXT: " + item.ToString());
            try
            {
                FileStream fs = FileUtils.Append(path);
                FileUtils.Escribir(fs, item.ToString());
                return Select(item.Guid);
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
            finally
            {
                log.Debug("Salir metode Add TXT: " + item.ToString());
            }
        }

        public List<T> GetAlumnos()
        {
            log.Debug("Entrar metodo GetAlumnos: ");
            try
            {
                FileStream fs = FileUtils.Abrir(path);
                List<String> list = FileUtils.LeerAllFile(fs);

                List<T> lalumnos = new List<T>();
                foreach (String item in list)
                {
                    string[] fields = item.Split(';');
                    Alumno alumno = new Alumno(int.Parse(fields[0]), fields[1], fields[2], fields[3], Convert.ToDateTime(fields[4]), Convert.ToInt32(fields[5]), fields[6], fields[7]);
                    lalumnos.Add(alumno as T);
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

        public T Select(string guid)
        {
            log.Debug("Entrar metodo Select TXT: ");
            try
            {
                if (File.Exists(path))
                {
                    FileStream fs = FileUtils.Abrir(path);

                    using (StreamReader sw = new StreamReader(fs))
                    {
                        string line;
                        bool trobat = false;
                        T elementT = default(T);
                        while ((line = FileUtils.LeerRegistro(sw)) != null && trobat == false)
                        {
                            string[] fields = line.Split(';');
                            if (fields[7].Equals(guid))
                            {
                                //object[] mParam = new object[] { fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7] };
                                //elementT = (T)Activator.CreateInstance(typeof(T), mParam);
                                Alumno alumno = new Alumno(int.Parse(fields[0]), fields[1], fields[2], fields[3], Convert.ToDateTime(fields[4]), Convert.ToInt32(fields[5]), fields[6], fields[7]);
                                elementT = alumno as T;
                                trobat = true;
                            }
                        }
                        return elementT;
                    }
                }
                else
                {
                    return null;
                }

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
        #endregion
    }
}
