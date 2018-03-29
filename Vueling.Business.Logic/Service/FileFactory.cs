using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.DataAcces.Dao;

namespace Vueling.Business.Logic
{
    public class FileFactory : TypeFactory
    {
        public override Formato CrearFormatoJson()
        {
            throw new NotImplementedException();
        }

        public override Formato CrearFormatoTxt()
        {
            throw new NotImplementedException();
        }

        public override Formato CrearFormatoXml()
        {
            throw new NotImplementedException();
        }
    }
}
