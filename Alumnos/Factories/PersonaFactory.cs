using Alumnos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alumnos.Enums.TiposPersona;

namespace Alumnos
{
    public static class PersonaFactory
    {
        public static Persona CrearPersona(TiposPersona.TipoPersona tipoPersona, int id, string nombre, string apellidos, string dni)
        {
            switch(tipoPersona)
            {
                case TipoPersona.Alumno:
                    return new Alumno(id, nombre, apellidos, dni);
                default:
                    return new Alumno(id, nombre, apellidos, dni);
            }
        }
    }
}
