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
        private DateTime fechaNac;
        private int edad;
        private string fechaCr;
        #endregion

        #region Constructores
        public Alumno() { }

        public Alumno(int id, string name, string apellidos, string dni, DateTime fechaNac) :
            this(id, name, apellidos, dni, fechaNac, 0, "", "")
        { }

        public Alumno(int id, string name, string apellidos, string dni, DateTime fechaNac, int edad, string fechaCr, string guid)
        {
            Id = id;
            Name = name;
            Apellidos = apellidos;
            Dni = dni;
            FechaNac = fechaNac;
            Edad = edad;
            FechaCr = fechaCr;
            Guid = guid;
        }
        #endregion

        #region Propiedades
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Dni { get => dni; set => dni = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public int Edad { get => edad; set => edad = value; }
        public string FechaCr { get => fechaCr; set => fechaCr = value; }
        #endregion

        #region Metodos
        public int CalcularEdat()
        {
            DateTime CurrentDate = DateTime.Now;
            return CurrentDate.Year - this.fechaNac.Year;
        }

        public String GetTimesTamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

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
                Edad = this.edad,
                FechaCr = this.fechaCr,
                Guid = this.Guid
            };

            return JsonConvert.SerializeObject(alumn, Formatting.Indented);
        }

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   base.Equals(obj) &&
                   id == alumno.id &&
                   name == alumno.name &&
                   apellidos == alumno.apellidos &&
                   dni == alumno.dni &&
                   fechaNac == alumno.fechaNac &&
                   edad == alumno.edad &&
                   fechaCr == alumno.fechaCr &&
                   Id == alumno.Id &&
                   Name == alumno.Name &&
                   Apellidos == alumno.Apellidos &&
                   Dni == alumno.Dni &&
                   FechaNac == alumno.FechaNac &&
                   Edad == alumno.Edad &&
                   FechaCr == alumno.FechaCr;
        }

        public override int GetHashCode()
        {
            var hashCode = -1156335184;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(dni);
            hashCode = hashCode * -1521134295 + fechaNac.GetHashCode();
            hashCode = hashCode * -1521134295 + edad.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(fechaCr);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + FechaNac.GetHashCode();
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FechaCr);
            return hashCode;
        }

        #endregion
    }
}
