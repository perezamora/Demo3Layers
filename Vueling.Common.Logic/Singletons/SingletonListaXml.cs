using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.Common.Logic.Singletons
{
    public class SingletonListaXml
    {
        private static SingletonListaXml _instancia = null;
        private List<Alumno> alumnos;

        private SingletonListaXml()
        {
            alumnos = new List<Alumno>();
        }

        // Property de solo lectura
        public static SingletonListaXml Instance
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SingletonListaXml();

                // Se devuelve la instancia
                return _instancia;
            }
        }

        public List<Alumno> ListaAlumnos { get => alumnos; set => alumnos = value; }
    }
}
