using System;
using Alumnos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlumnosTest
{
    [TestClass]
    public class AlumnoIntegrationTest
    {
        [DataRow(1, "Pepi", "Garcia", "1234")]
        [DataTestMethod]
        public void AlumnoTest(int id, string nombre, string apellidos, string dni)
        {
            Alumno alumno = new Alumno(id, nombre, apellidos, dni);
            Assert.IsTrue(id == alumno.Id);
            Assert.IsTrue(nombre == alumno.Nombre);
            Assert.IsTrue(apellidos == alumno.Apellidos);
            Assert.IsTrue(dni == alumno.Dni);
        }
    }
}
