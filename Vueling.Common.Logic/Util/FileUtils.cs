using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vueling.Common.Logic.Util;
using log4net;
using System.Reflection;
using Newtonsoft.Json;

namespace Vueling.Common.Logic.Util
{
    public static class FileUtils
    {
        private static ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public static String GetPath()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                var nameFile = Resources.ConfigRes.file + ConfigUtils.GetValorVarEnvironment(Resources.ConfigRes.Format);
                var filePath = ConfigUtils.GetValorVarEnvironment(nameFile);
                var fullPath = path + Resources.ConfigRes.slash + filePath;
                log.Debug(nameFile);
                log.Debug(filePath);
                log.Debug(fullPath);

                return fullPath;
            }
            catch (IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public static FileStream Crear(string pathFile)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            FileStream fs;
            try
            {
                if (!File.Exists(pathFile))
                {
                    fs = new FileStream(pathFile, FileMode.Create, FileAccess.Write);
                    return fs;
                }
                else
                {
                    fs = new FileStream(pathFile, FileMode.Open, FileAccess.Write);
                    return fs;
                }
            }
            catch (FileNotFoundException e)
            {
                log.Fatal(e.Message + e.StackTrace);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public static FileStream Append(string pathFile)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                var fs = new FileStream(pathFile, FileMode.Append, FileAccess.Write);
                return fs;
            }
            catch (IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public static FileStream Abrir(string pathFile)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                var fs = new FileStream(pathFile, FileMode.Open);
                return fs;
            }
            catch (FileNotFoundException e)
            {
                log.Fatal(e.Message + e.StackTrace);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public static void Escribir(FileStream fs, string contenido)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(contenido);
                }
            }
            catch (FileNotFoundException e)
            {
                log.Fatal(e.Message + e.StackTrace);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public static List<String> LeerAllFile(FileStream fs)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                List<string> list = new List<string>();
                using (StreamReader sw = new StreamReader(fs))
                {
                    string line;
                    while ((line = sw.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                    return list;
                }

            }
            catch (FileNotFoundException e)
            {
                log.Fatal(e.Message + e.StackTrace);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public static string LeerRegistro(StreamReader sw)
        {
            return sw.ReadLine();
        }

        public static void Cerrar(FileStream fs)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                fs.Close();
            }
            catch (FileNotFoundException e)
            {
                log.Fatal(e.Message + e.StackTrace);
                throw;
            }
            catch (IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public static T DeserializarJson<T>(string item)
        {
            log.Debug("DeserializarJson: " + item);
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                Resources.logmessage.valueMethod + item.ToString());
            return JsonConvert.DeserializeObject<T>(item);
        }

        public static string SerializarJson<T>(T item)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name +
                Resources.logmessage.valueMethod + item.ToString());
            return JsonConvert.SerializeObject(item);
        }
    }
}
