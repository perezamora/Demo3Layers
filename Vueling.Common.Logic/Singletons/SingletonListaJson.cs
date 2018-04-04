using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.Common.Logic.Singletons
{
    public class SingletonListaJson
    {
        private static SingletonListaJson _instancia = null;
        private List<Alumno> alumos;

        private SingletonListaJson()
        {
            alumos = new List<Alumno>();
        }

        // Property de solo lectura
        public static SingletonListaJson Instance
        {
            get
            {
                if (_instancia == null)
                    _instancia = new SingletonListaJson();

                // Se devuelve la instancia
                return _instancia;
            }
        }

        public List<Alumno> ListaAlunmnos { get => alumos; set => alumos = value; }

    }
}
