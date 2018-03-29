﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Util;

namespace Vueling.Common.Logic.Enums
{
    public class EnumApp
    {
        public enum OpcTypeFile
        {
            Txt = 1,
            Json = 2,
            Xml = 3
        }

        public static OpcTypeFile getValorFormatAlumno()
        {
            var opcSerial = ConfigUtils.GetValorVarEnvironment();
            return (OpcTypeFile)Enum.Parse(typeof(OpcTypeFile), opcSerial, true);
        }
    }
}
