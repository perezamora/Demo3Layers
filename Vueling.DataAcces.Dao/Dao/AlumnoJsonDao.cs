using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using System.IO;
using Vueling.Common.Logic.Util;
using log4net;
using System.Reflection;

namespace Vueling.DataAcces.Dao
{
    public class AlumnoJsonDao : IAlumnoFormatoDao
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Alumno Add(Alumno alumno)
        {
            log.Debug("Entrar metodo Add: " + alumno.ToString());
            FileStream fs = FileUtils.Append(FileUtils.getPath());
            FileUtils.Escribir(fs, alumno.ToJson());
            LogUtilSer.WriteDebugSerilog(alumno.ToString());
            return alumno;
        }
    }
}
