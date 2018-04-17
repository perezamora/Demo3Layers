﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.Business.Logic.Interfaces
{
    public interface ICrudBL: ICreateBL, IReadBL, IUpdateBL, IDeleteBL
    {
    }
}
