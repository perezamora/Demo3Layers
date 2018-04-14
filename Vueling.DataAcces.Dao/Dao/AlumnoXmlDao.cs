using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

namespace Vueling.DataAcces.Dao.Dao
{

    public class AlumnoXmlDao<T> : IAlumnoFormatoDao<T> where T : VuelingObject
    {
        private readonly ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string path;

        public AlumnoXmlDao()
        {
            path = FileUtils.GetPath();
        }

        #region Metodos
        public T Add(T item)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name 
                + Resources.logmessage.valueMethod + item.ToString());

            try
            {
                if (File.Exists(path))
                {
                    List<T> alumnos;
                    XmlSerializer xSeriz = new XmlSerializer(typeof(List<Alumno>));
                    using (StreamReader r = new StreamReader(path))
                    {
                        String xml = r.ReadToEnd();
                        StringReader stringReader = new StringReader(xml);
                        alumnos = (List<T>)xSeriz.Deserialize(stringReader);
                        alumnos.Add(item);
                    }

                    using (FileStream fs1 = new FileStream(path, FileMode.Open))
                        xSeriz.Serialize(fs1, alumnos);
                }
                else
                {
                    List<T> alumnos = new List<T>();
                    XmlSerializer xSeriz = new XmlSerializer(typeof(List<Alumno>));
                    using (FileStream fs1 = new FileStream(path, FileMode.Create))
                    {
                        alumnos.Add(item);
                        xSeriz.Serialize(fs1, alumnos);
                    }
                }
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
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                List<T> alumnos = new List<T>();
                if (File.Exists(path))
                {

                    XmlSerializer xSeriz = new XmlSerializer(typeof(List<Alumno>));
                    using (StreamReader r = new StreamReader(path))
                    {
                        String xml = r.ReadToEnd();
                        StringReader stringReader = new StringReader(xml);
                        alumnos = (List<T>)xSeriz.Deserialize(stringReader);
                    }
                    log.Debug(alumnos);
                }

                return alumnos;
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
                List<T> listaItems = GetAll();
                var filterItems = from n in listaItems
                                  where n.Guid == guid
                                  select n;
                return filterItems.FirstOrDefault<T>();
            }catch(IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }catch(Exception e)
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
