using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAcces.Dao;
using Vueling.Common.Logic.Util;
using Vueling.Common.Logic;
using System.Reflection;
using log4net;

namespace Vueling.Business.Logic
{
    public class AlumnoBL : IAlumnoBL
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IAlumnoFormatoDao alumnoDao;

        public AlumnoBL()
        {
        }

        private void ReflectionMetodoFactoria()
        {
            // Factoria tipos
            ITypeFactory factory = new FileFactory();

            // Nombre del metodo segun el formato escogido
            string metodo = "Type" + TypeFileEnum.getValorFormatAlumno();

            // Reflection sobre clase Factory -> escoger tipo
            Type myTypeObj = factory.GetType();

            // Reflection sobre informacion del metodo "Add" clase factory
            MethodInfo info = myTypeObj.GetMethod(metodo);
            object[] mParam = new object[] { };

            // Invocamos el metodo en tiempo ejecucion (Reflection)
            alumnoDao = (IAlumnoFormatoDao)info.Invoke(factory, mParam);
        }

        public Alumno Add(Alumno alumno)
        {
            log.Debug("Entrar metodo Add: " + alumno.ToString());
            try
            {
                ReflectionMetodoFactoria();
                alumno.Edad = alumno.CalcularEdat();
                alumno.FechaCr = alumno.GetTimesTamp(DateTime.Now);
                return alumnoDao.Add(alumno);
            }
            catch (Exception e)
            {
                log.Error("Catch Add: " + e.ToString());
                throw;
            }

        }

        public List<Alumno> GetAlumnos()
        {
            log.Debug("Entrar metodo GetAlumnos: ");
            try
            {
                ReflectionMetodoFactoria();
                return alumnoDao.GetAlumnos();
            }
            catch (Exception e)
            {
                log.Error("Catch Add: " + e.ToString());
                throw;
            }
        }
    }
}
