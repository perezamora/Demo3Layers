using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAcces.Dao;

namespace Vueling.Business.Logic
{
    public class FileFactory : ITypeFactory
    {
        public IAlumnoFormatoDao TypeTxt()
        {
            return new AlumnoTxtDao();
        }

        public IAlumnoFormatoDao TypeJson()
        {
            return new AlumnoJsonDao();
        }

        public IAlumnoFormatoDao TypeXml()
        {
            return new AlumnoXmlDao();
        }
    }
}
