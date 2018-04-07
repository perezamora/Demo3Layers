using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAcces.Dao;

namespace Vueling.Business.Logic
{
    public class FileFactory<T> : ITypeFactory<T> where T : VuelingObject
    {
        public IAlumnoFormatoDao<T> TypeTxt()
        {
            return new AlumnoTxtDao<T>();
        }

        public IAlumnoFormatoDao<T> TypeJson()
        {
            return new AlumnoJsonDao<T>();
        }

        public IAlumnoFormatoDao<T> TypeXml()
        {
            return new AlumnoXmlDao<T>();
        }
    }
}
