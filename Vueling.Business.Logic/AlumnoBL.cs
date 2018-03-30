using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAcces.Dao;
using Vueling.Common.Logic.Util;
using Vueling.Common.Logic.Enums;

namespace Vueling.Business.Logic
{
    public class AlumnoBL : IAlumnoBL
    {
        private IAlumnoFormatoDao alumnoDao;

        public Alumno Add(Alumno alumno)
        {
            ITypeFactory factory = new FileFactory();
            alumno.Edad = alumno.CalcularEdat();
            alumno.FechaCr = alumno.GetTimestamp(DateTime.Now);

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
            }

            return new Alumno();
        }
    }
}
