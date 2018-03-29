using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vueling.Common.Logic.Model
{
    public class Alumno : VuelingObject
    {
        #region Atributos
        private int id;
        private string name;
        private string apellidos;
        private string dni;
        private string fechaNac;
        private int edad;
        private string fechaCr;
        #endregion

        #region Constructores
        public Alumno() { }

        public Alumno(int id, string name, string apellidos, string dni, string fechaNac)
        {
            this.id = id;
            this.name = name;
            this.apellidos = apellidos;
            this.dni = dni;
            this.fechaNac = fechaNac;
        }
        #endregion

        #region Propiedades
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Dni { get => dni; set => dni = value; }
        public string FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public string FechaCr { get => fechaCr; set => fechaCr = value; }
        #endregion

        public override String ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7};",
                this.id, this.name, this.apellidos, this.dni, this.fechaNac, this.edad, this.fechaCr, this.Guid);
        }

        public string ToJson()
        {
            Alumno alumn = new Alumno
            {
                Id = this.id,
                Name = this.name,
                Apellidos = this.apellidos,
                Dni = this.dni,
                FechaNac = this.fechaNac,
            };

            return JsonConvert.SerializeObject(alumn, Formatting.Indented);
        }

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   id == alumno.id &&
                   name == alumno.name &&
                   apellidos == alumno.apellidos &&
                   dni == alumno.dni &&
                   fechaNac == alumno.fechaNac;
        }

        public override int GetHashCode()
        {
            var hashCode = 394487252;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(fechaNac);
            return hashCode;
        }

    }
}
