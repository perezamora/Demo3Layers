using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vueling.Common.Logic.Util;

namespace Vueling.Common.Logic.Util
{
    public static class FileUtils
    {
        public static String getPath()
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

        public static FileStream Crear(string pathFile)
        {
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
            FileStream fs = new FileStream(pathFile, FileMode.Append, FileAccess.Write);
            return fs;
        }

        public static FileStream Abrir(string pathFile)
        {
            FileStream fs = new FileStream(pathFile, FileMode.Open, FileAccess.Write);
            return fs;
        }

        public static void Escribir(FileStream fs, string contenido)
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(contenido);
            }
        }
    }
}
