using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
    public class Alumno : Persona
    {
        [JsonConstructor]
        public Alumno(int id, string nombre, string apellidos, string dni) : base(id, nombre, apellidos, dni)
        {

        }

        public Alumno(int id, string nombre, string apellidos, string dni, string guid) : base(id, nombre, apellidos, dni, guid)
        {

        }
    }
}
