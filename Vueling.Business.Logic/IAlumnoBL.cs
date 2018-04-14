using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.Business.Logic
{
    public interface IAlumnoBL
    {
        Alumno Add(Alumno alumno);

        Alumno Select(int id);

        Alumno Update(Alumno alumno);

        void Delete(int id);

        List<Alumno> GetAlumnos();
    }
}
