using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alumnos.Enums.TiposPersona;

namespace Alumnos.Tests
{
    [TestClass()]
    public class PersonaFactoryTests
    {
        PersonaFactory personaFactory = new PersonaFactory();

        [DataRow(TipoPersona.Alumno, 1, "Leia", "Organa", "1234")]
        [DataTestMethod]
        public void CrearPersonaTest(TipoPersona tipoPersona, int id, string nombre, string apellidos, string dni)
        {
            Persona persona = (Persona)personaFactory.CrearPersona(tipoPersona, id, nombre, apellidos, dni);
            switch (tipoPersona)
            {
                case TipoPersona.Alumno:
                    Assert.IsTrue(persona.GetType() == typeof(Alumno));
                    break;
            }
        }
    }
}