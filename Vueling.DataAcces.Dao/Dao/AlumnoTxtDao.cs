using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;
using System.IO;
using System.Reflection;

namespace Vueling.DataAcces.Dao.Dao
{
    public class AlumnoTxtDao<T> : IAlumnoFormatoDao<T> where T : VuelingObject
    {
        private readonly ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string path;

        #region Constructores
        public AlumnoTxtDao()
        {
            path = FileUtils.GetPath();
        }
        #endregion

        #region Metodos
        public T Add(T item)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name
                + Resources.logmessage.valueMethod + item.ToString());
            try
            {
                FileStream fs = FileUtils.Append(path);
                FileUtils.Escribir(fs, item.ToString());
                return this.Select(item.Guid);
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
                log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
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

        public T SelectId(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
