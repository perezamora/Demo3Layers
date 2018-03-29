using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;
using System.IO;

namespace Vueling.DataAcces.Dao
{
    public class AlumnoTxtDao : IAlumnoFormatoDao
    {

        public Alumno Add(Alumno alumno)
        {
            FileStream fs = FileUtils.Append(FileUtils.getPath());
            FileUtils.Escribir(fs, alumno.ToString());
            return alumno;
        }
    }
}
