using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAcces.Dao.Dao
{
    public interface IDeleteDao<T>
    {
        T Delete(T id);
    }
}
