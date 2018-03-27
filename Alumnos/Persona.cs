using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Alumno_Guid { get; set; }

        public Persona(int id, string nombre, string apellidos, string dni)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Dni = dni;
            this.Alumno_Guid = Guid.NewGuid().ToString();
        }

        public Persona(int id, string nombre, string apellidos, string dni, string guid)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Dni = dni;
            this.Alumno_Guid = guid;
        }


        public override int GetHashCode()
        {
            var hashCode = -28937434;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Alumno_Guid);
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var persona = obj as Persona;
            return persona != null &&
                   Id == persona.Id &&
                   Nombre == persona.Nombre &&
                   Apellidos == persona.Apellidos &&
                   Dni == persona.Dni &&
                   Alumno_Guid == persona.Alumno_Guid;
        }
    }
}
