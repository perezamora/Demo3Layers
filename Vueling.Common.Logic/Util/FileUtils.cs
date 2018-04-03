using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vueling.Common.Logic.Util;
using log4net;
using System.Reflection;

namespace Vueling.Common.Logic.Util
{
    public static class FileUtils
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static String getPath()
        {
            log.Debug("Entrar metodo getPath: ");

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

        public static FileStream Crear(string pathFile)
        {
            log.Debug("Entrar metodo Crear: ");

            FileStream fs;
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

        public static FileStream Append(string pathFile)
        {
            log.Debug("Entrar metodo Append: ");
            FileStream fs = new FileStream(pathFile, FileMode.Append, FileAccess.Write);
            return fs;
        }

        public static FileStream Abrir(string pathFile)
        {
            log.Debug("Entrar metodo Abrir: ");
            FileStream fs = new FileStream(pathFile, FileMode.Open, FileAccess.Write);
            return fs;
        }

        public static void Escribir(FileStream fs, string contenido)
        {
            log.Debug("Entrar metodo Escribir: ");
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(contenido);
            }
        }
    }
}
