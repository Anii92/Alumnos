using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Alumnos.Tests
{
    [TestClass()]
    public class FicheroTxtTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ConfiguracionController configuracionController = new ConfiguracionController();
            configuracionController.EliminarConfiguracion();
            configuracionController.CrearConfiguracionFichero("Texto");
            string pathFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt");
            if (File.Exists(pathFile))
            {
                File.Delete(pathFile);
            }
        }

        [DataRow(1, "Leia", "Organa", "1234")]
        [DataTestMethod]
        public void GuardarTxtTest(int id, string nombre, string apellidos, string dni)
        {
            string pathFichero = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt");
            Alumno alumno = new Alumno(1, "Leia", "Organa", "1234");
            FicheroTxt ficheroTxt = new FicheroTxt("ListadoDeAlumnos.txt", pathFichero);
            ficheroTxt.Guardar(alumno);
            Assert.IsTrue(File.Exists(pathFichero));

            string[] liniaFichero = null;
            foreach (var line in File.ReadAllLines(pathFichero))
            {
                liniaFichero = line.Split(',');
            }
            Alumno alumnoFichero = new Alumno(Convert.ToInt32(liniaFichero[0]), liniaFichero[1], liniaFichero[2], liniaFichero[3], liniaFichero[4]);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }
    }
}