using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAcces.Dao.Dao;
using Vueling.Common.Logic.Util;
using Vueling.Common.Logic;
using System.Reflection;
using Vueling.Business.Logic.Interfaces;

namespace Vueling.Business.Logic
{
    public class AlumnoBL : IAlumnoBL, ICrudBL
    {
        private readonly ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        private IAlumnoFormatoDao<Alumno> alumnoDao;
        private ICrudDao<Alumno> alumnoCrudDao;

        private void ReflectionMetodoFactoria()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            // Factoria tipos
            ITypeFactory<Alumno> factory = new FileFactory<Alumno>();

            // Nombre del metodo segun el formato escogido
            string metodo = "Type" + TypeFileEnum.getValorFormatAlumno();

            // Reflection sobre clase Factory -> escoger tipo
            Type myTypeObj = factory.GetType();

            // Reflection sobre informacion del metodo "Add" clase factory
            MethodInfo info = myTypeObj.GetMethod(metodo);
            object[] mParam = new object[] { };

            // Invocamos el metodo en tiempo ejecucion (Reflection)
            alumnoDao = (IAlumnoFormatoDao<Alumno>)info.Invoke(factory, mParam);
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public Alumno Add(Alumno alumno)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name
                + Resources.logmessage.valueMethod + alumno.ToString());
            try
            {
                ReflectionMetodoFactoria();
                alumno.Edad = CalcularEdat(alumno.FechaNac);
                alumno.FechaCr = CalcularDateCreate();
                return alumnoDao.Add(alumno);
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public List<Alumno> GetAlumnos()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                ReflectionMetodoFactoria();
                return alumnoDao.GetAll();
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public int CalcularEdat(DateTime fechaNacimiento)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            DateTime CurrentDate = DateTime.Now;
            var edad = CurrentDate.Year - fechaNacimiento.Year;
            if (CurrentDate.Month < fechaNacimiento.Month || (CurrentDate.Month == fechaNacimiento.Month && CurrentDate.Day < fechaNacimiento.Day))
                edad--;
            log.Debug(Resources.logmessage.endMethod + System.Reflection.MethodBase.GetCurrentMethod().Name
                + Resources.logmessage.valueMethod + edad);
            return edad;
        }

        private String CalcularDateCreate()
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        public Alumno Insert(Alumno alumno)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            alumnoCrudDao = new AlumnoSqlDao<Alumno>();
            try
            {
                alumno.Edad = CalcularEdat(alumno.FechaNac);
                alumno.FechaCr = CalcularDateCreate();
                return alumnoCrudDao.Insert(alumno);
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }

        }

        public Alumno Select(string guid)
        {
            throw new NotImplementedException();
        }

        public Alumno SelectById(Alumno alumno)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            alumnoCrudDao = new AlumnoSqlDao<Alumno>();
            try
            {
                return alumnoCrudDao.SelectById(alumno);
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public Alumno Update(Alumno alumno)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            alumnoCrudDao = new AlumnoSqlDao<Alumno>();
            try
            {
                alumno.Edad = CalcularEdat(alumno.FechaNac);
                return alumnoCrudDao.Update(alumno);
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }

        public int Delete(Alumno alumno)
        {
            log.Debug(Resources.logmessage.startMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            alumnoCrudDao = new AlumnoSqlDao<Alumno>();
            try
            {
                return alumnoCrudDao.Delete(alumno);
            }
            catch (Exception e)
            {
                log.Error(e.Message + e.StackTrace);
                throw;
            }
        }
    }
}