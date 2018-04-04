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
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static String getPath()
        {
            log.Debug("Entrar metodo getPath: ");

            try
            {
                // Path de misdocumentos
                String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Nombre del fichero añadir elementos
                var nameFile = "file" + ConfigUtils.GetValorVarEnvironment();
                var filePath = Environment.GetEnvironmentVariable(nameFile);
                var fullPath = path + "\\" + filePath;
                Console.WriteLine(nameFile);
                Console.WriteLine(filePath);
                Console.WriteLine("file path -->" + fullPath);

                return fullPath;
            }
            catch (IOException e)
            {
                log.Debug("Catch GetPath: " + e);
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
            catch (IOException e)
            {
                log.Debug("Catch Crear: " + e);
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
                log.Debug("Catch Append: " + e);
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
            catch (IOException e)
            {
                log.Debug("Catch Abrir: " + e);
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
            catch (IOException e)
            {
                log.Debug("Catch Escribir: " + e);
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
            catch (IOException e)
            {
                log.Debug("Catch LeerAllFile: " + e);
                throw;
            }

        }

        public static void Cerrar(FileStream fs)
        {
            log.Debug("Cerrar fichero: ");
            try
            {
                fs.Close();
            }
            catch (IOException e)
            {
                log.Debug("Catch Cerrar: " + e);
                throw;
            }

        }

        public static T DeserializarJson<T>(string item)
        {
            log.Debug("DeserializarJson: " + item);
            return JsonConvert.DeserializeObject<T>(item);
        }
    }
}
