using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Model
{
    public class VuelingObject
    {
        private String guid;

        public VuelingObject()
        {
            this.guid = System.Guid.NewGuid().ToString();
        }

        public string Guid { get => guid; set => guid = value; }
    }
}
