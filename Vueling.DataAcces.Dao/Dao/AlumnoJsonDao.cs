using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using System.IO;
using Vueling.Common.Logic.Util;

namespace Vueling.DataAcces.Dao
{
    public class AlumnoJsonDao : IAlumnoFormatoDao
    {
        public Alumno Add(Alumno alumno)
        {
            FileStream fs = FileUtils.Append(FileUtils.getPath());
            FileUtils.Escribir(fs, alumno.ToJson());
            return alumno;
        }
    }
}
