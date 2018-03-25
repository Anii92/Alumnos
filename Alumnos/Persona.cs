using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
    public abstract class Persona : IEquatable<Persona>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }

        public Persona(int id, string nombre, string apellidos, string dni)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Dni = dni;
        }

        public bool Equals(Persona other)
        {
            if (other == null) return false;
            return this.Id == other.Id && this.Nombre == other.Nombre && this.Apellidos == other.Apellidos && this.Dni == other.Dni;
        }
    }
}
