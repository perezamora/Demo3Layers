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

        public override bool Equals(object obj)
        {
            var @object = obj as VuelingObject;
            return @object != null &&
                   guid == @object.guid &&
                   Guid == @object.Guid;
        }

        public override int GetHashCode()
        {
            var hashCode = 1574576152;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(guid);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Guid);
            return hashCode;
        }
    }
}
