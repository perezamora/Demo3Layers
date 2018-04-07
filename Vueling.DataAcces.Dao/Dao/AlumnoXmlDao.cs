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
using log4net;

namespace Vueling.DataAcces.Dao
{
    
    public class AlumnoXmlDao<T> : IAlumnoFormatoDao<T> where T : VuelingObject
    {
        private readonly AdapterLog4NetLogger log = new AdapterLog4NetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string path; 

        public AlumnoXmlDao()
        {
            path = FileUtils.GetPath();
        }

        #region Metodos
        public T Add(T item)
        {
            log.Debug("Entrar metodo Add: " + item.ToString());

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
            throw new NotImplementedException();
        }
        #endregion
    }
}
