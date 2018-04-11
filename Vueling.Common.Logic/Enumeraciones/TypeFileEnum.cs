using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Util;

namespace Vueling.Common.Logic
{
    public class TypeFileEnum
    {
        public enum OpcTypeFile
        {
            Txt = 1,
            Json = 2,
            Xml = 3,
            Sql = 4
        }

        public static OpcTypeFile getValorFormatAlumno()
        {
            var opcSerial = ConfigUtils.GetValorVarEnvironment();
            return (OpcTypeFile)Enum.Parse(typeof(OpcTypeFile), opcSerial, true);
        }
    }
}
