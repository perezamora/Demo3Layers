using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAcces.Dao
{
    public class Alumno: VuelingObject
    {
        #region Atributos
        private int id;
        private String name;
        private String apellidos;
        private String dni;
        private String guid;
        private DateTime fechaNacimiento;
        private int edad;
        private String fechaCreacion;
        #endregion

        #region Propiedades
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Guid { get => guid; set => guid = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public string FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; } 
        #endregion
    }
}
