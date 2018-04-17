using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAcces.Dao.Dao
{
    public interface IAlumnoFormatoDao<T> where T : VuelingObject
    {
        #region Metodos
        T Add(T item);
        List<T> GetAll();
        #endregion
    }
}
