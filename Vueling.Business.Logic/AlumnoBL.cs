using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAcces.Dao;
using Vueling.Common.Logic.Util;
using Vueling.Common.Logic.Enums;
using System.Reflection;

namespace Vueling.Business.Logic
{
    public class AlumnoBL : IAlumnoBL
    {
        private IAlumnoFormatoDao alumnoDao;

        public Alumno Add(Alumno alumno)
        {
            /*
            ITypeFactory factory = new FileFactory();
            alumno.Edad = alumno.CalcularEdat();
            alumno.FechaCr = alumno.GetTimesTamp(DateTime.Now);
            LogUtilSer.WriteInfoSerilog(alumno.ToString());

            switch (EnumApp.getValorFormatAlumno())
            {
                case EnumApp.OpcTypeFile.Txt:
                    alumnoDao = factory.AddTxt();
                    alumnoDao.Add(alumno);
                    break;
                case EnumApp.OpcTypeFile.Json:
                    alumnoDao = factory.AddJson();
                    alumnoDao.Add(alumno);
                    break;
                case EnumApp.OpcTypeFile.Xml:
                    alumnoDao = factory.AddXml();
                    alumnoDao.Add(alumno);
                    break;
            }*/

            // Factoria tipos
            ITypeFactory factory = new FileFactory();
            alumno.Edad = alumno.CalcularEdat();
            alumno.FechaCr = alumno.GetTimesTamp(DateTime.Now);

            // Nombre del metodo segun el formato escogido
            string metodo = "Add" + EnumApp.getValorFormatAlumno();

            // Reflection sobre clase Factori -> escoger tipo
            Type myTypeObj = factory.GetType();

            // Reflection sobre informacion del metodo "Add" clase factory
            MethodInfo info = myTypeObj.GetMethod(metodo);
            object[] mParam = new object[] { };
            LogUtilSer.WriteInfoSerilog(EnumApp.getValorFormatAlumno().ToString());
            
            // Invocamos el metodo en tiempo ejecucion (Reflection)
            alumnoDao = (IAlumnoFormatoDao)info.Invoke(factory, mParam);
            alumnoDao.Add(alumno);

            return new Alumno();
        }
    }
}
