using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Alumnos.Tests
{
    [TestClass()]
    public class FicheroJsonTests
    {
        [DataRow("MiPrimerFicheroJson.json", "C://Documentos")]
        [DataTestMethod]
        public void FicheroJsonTest(string nombre, string ruta)
        {
            FicheroJson ficheroJson = new FicheroJson(nombre, ruta);
            Assert.IsTrue(nombre == ficheroJson.Nombre);
            Assert.IsTrue(ruta == ficheroJson.Ruta);
        }

        [DataRow(1, "Leia", "Organa", "1234")]
        [DataTestMethod]
        public void GuardarJsonTest(int id, string nombre, string apellidos, string dni)
        {
            Alumno alumno = new Alumno(id, nombre, apellidos, dni);
            FicheroJson ficheroJson = new FicheroJson("ListadoDeAlumnos.json", System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
            ficheroJson.Guardar(alumno);
            Assert.IsTrue(File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json")));

            bool alumnoEncontrado = false;
            var jsonData = System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
            var alumnosList = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);
            foreach(var al in alumnosList)
            {
                if (alumno.Equals(al))
                {
                    alumnoEncontrado = true;
                    break;
                }
            }
            Assert.IsTrue(alumnoEncontrado);
        }

        
    }
}