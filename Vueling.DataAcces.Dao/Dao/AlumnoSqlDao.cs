using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;

namespace Vueling.DataAcces.Dao.Dao
{
    public class AlumnoSqlDao<T> : ICrudDao<T>
    {
        private readonly ILogger log = ConfigUtils.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private IDatabase database;

        #region Metodos
        public T Insert(T item)
        {
            throw new NotImplementedException();
        }

        public T Select(T guid)
        {
            throw new NotImplementedException();
        }

        public T SelectById(T id)
        {
            throw new NotImplementedException();
        }

        public T Update(T id)
        {
            throw new NotImplementedException();
        }

        public T Delete(T id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
