using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAcces.Dao.Dao
{
    public interface ICrudDao<T> : ICreateDao<T>, IReadDao<T>, IUpdateDao<T>, IDeleteDao<T>
    {
    }
}
