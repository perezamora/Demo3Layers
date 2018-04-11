using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAcces.Dao.Dao
{
    public class AlumnoSqlDao<T> : IAlumnoFormatoDao<T> where T : VuelingObject
    {
        public T Add(T item)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAlumnos()
        {
            throw new NotImplementedException();
        }

        public T Select(string guid)
        {
            throw new NotImplementedException();
        }
    }
}
