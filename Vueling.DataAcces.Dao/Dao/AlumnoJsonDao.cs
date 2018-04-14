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

namespace Vueling.DataAcces.Dao.Dao
{
    public class AlumnoJsonDao<T> : IAlumnoFormatoDao<T> where T : VuelingObject
    {
        private readonly ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string path;

        #region Constructores
        public AlumnoJsonDao()
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
                FileUtils.Escribir(fs, FileUtils.SerializarJson(item));
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
                log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name
                    + Resources.logmessage.valueMethod + item.ToString());
            }
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAlumnos()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                List<T> lalumnos = new List<T>();
                if (File.Exists(path))
                {
                    FileStream fs = FileUtils.Abrir(path);
                    List<String> list = FileUtils.LeerAllFile(fs);


                    foreach (String item in list)
                    {
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

        public T Select(string guid)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

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
                            var item = FileUtils.DeserializarJson<T>(line);
                            if (item.Guid.Equals(guid))
                            {
                                elementT = item;
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

        public T Update(T item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
