using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.DataAcces.Dao;

namespace Vueling.Business.Logic
{

    public abstract class TypeFactory
    {
        public abstract Formato CrearFormatoTxt();
        public abstract Formato CrearFormatoJson();
        public abstract Formato CrearFormatoXml();
    }

}
