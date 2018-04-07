using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAcces.Dao;

namespace Vueling.Business.Logic
{

    public interface ITypeFactory<T> where T : VuelingObject
    {
        IAlumnoFormatoDao<T> TypeTxt();
        IAlumnoFormatoDao<T> TypeJson();
        IAlumnoFormatoDao<T> TypeXml();
    }

}
