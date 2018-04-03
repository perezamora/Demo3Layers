using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.DataAcces.Dao;

namespace Vueling.DataAcces.Dao
{
  
    public interface IAlumnoFormatoDao
    {
        Alumno Add(Alumno alumno);
    }
}
