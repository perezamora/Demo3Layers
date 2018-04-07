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
        private static readonly AdapterLog4NetLogger log = new AdapterLog4NetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static String GetPath()
        {
            log.Debug("Entrar metodo GetPath: ");

            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                var slash = "\\";
                var nameFile = "file" + ConfigUtils.GetValorVarEnvironment();
                var filePath = Environment.GetEnvironmentVariable(nameFile);
                var fullPath = path + slash + filePath;

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
            log.Debug("Entrar metodo Crear: ");

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
            catch(IOException e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public static FileStream Append(string pathFile)
        {
            log.Debug("Entrar metodo Append: ");
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
            log.Debug("Entrar metodo Abrir: " + pathFile);
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
            log.Debug("Entrar metodo Escribir: ");
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
            log.Debug("Entrar metodo Leer: ");
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
            log.Debug("Cerrar fichero: ");
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
            return JsonConvert.DeserializeObject<T>(item);
        }

        public static string SerializarJson<T>(T item)
        {
            log.Debug("SerializarJson: " + item.ToString());
            return JsonConvert.SerializeObject(item);
        }
    }
}
