using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace Alumnos.Tests
{
    [TestClass()]
    public class FicheroJsonTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ConfiguracionController configuracionController = new ConfiguracionController();
            configuracionController.EliminarConfiguracion();
            configuracionController.CrearConfiguracionFichero("Json");
            string pathFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json");
            if (File.Exists(pathFile))
            {
                File.Delete(pathFile);
            }
        }

        [DataRow(1, "Leia", "Organa", "1234")]
        [DataTestMethod]
        public void GuardarJsonTest(int id, string nombre, string apellidos, string dni)
        {
            string pathFichero = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json");
            Alumno alumno = new Alumno(id, nombre, apellidos, dni);
            FicheroJson ficheroJson = new FicheroJson("ListadoDeAlumnos.json", pathFichero);
            ficheroJson.Guardar(alumno);
            Assert.IsTrue(File.Exists(pathFichero));

            var jsonData = System.IO.File.ReadAllText(pathFichero);
            List<Alumno> alumnosList = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);
            Alumno alumnoFichero = new Alumno(alumnosList[0].Id, alumnosList[0].Nombre, alumnosList[0].Apellidos, alumnosList[0].Dni, alumnosList[0].Alumno_Guid);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }
    }
}