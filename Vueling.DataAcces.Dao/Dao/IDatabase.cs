﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAcces.Dao.Dao
{
    public interface IDatabase
    {
        IDbConnection CreateOpenConnection();
    }
}