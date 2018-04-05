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
                var slash = "\\";
                var nameFile = "file" + ConfigUtils.GetValorVarEnvironment();
                var filePath = Environment.GetEnvironmentVariable(nameFile);
                var fullPath = path + slash + filePath;
                Console.WriteLine(nameFile);
                Console.WriteLine(filePath);
                Console.WriteLine("file path -->" + fullPath);

                return fullPath;
            }
            catch (IOException e)
            {
                log.Error("Catch GetPath: " + e);
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
                log.Fatal("Catch Crear File not found: " + e);
                throw;
            }
            catch(Exception e)
            {
                log.Error("Catch crear exception general " + e);
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
                log.Error("Catch Append: " + e);
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
                log.Fatal("Catch Abrir File not found: " + e);
                throw;
            }
            catch (IOException e)
            {
                log.Error("Catch Abrir: " + e);
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
                log.Fatal("Catch Escribir File not found: " + e);
                throw;
            }
            catch (IOException e)
            {
                log.Error("Catch Escribir: " + e);
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
                log.Fatal("Catch LeerAllFile File not found: " + e);
                throw;
            }
            catch (IOException e)
            {
                log.Error("Catch LeerAllFile: " + e);
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
            catch (FileNotFoundException e)
            {
                log.Fatal("Catch Cerrar File not found: " + e);
                throw;
            }
            catch (IOException e)
            {
                log.Error("Catch Cerrar: " + e);
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
