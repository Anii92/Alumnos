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
        [DataRow("MiPrimerFicheroTxt.txt", "C://Documentos")]
        [DataTestMethod]
        public void FicheroTxtTest(string nombre, string ruta)
        {
            FicheroTxt ficheroTxt = new FicheroTxt(nombre, ruta);
            Assert.IsTrue(nombre == ficheroTxt.Nombre);
            Assert.IsTrue(ruta == ficheroTxt.Ruta);
        }

        [TestMethod()]
        public void GuardarTxtTest()
        {
            Alumno alumno = new Alumno(1, "Leia", "Organa", "1234");
            FicheroTxt ficheroTxt = new FicheroTxt("ListadoDeAlumnos.txt", System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
            ficheroTxt.Guardar(alumno);
            Assert.IsTrue(File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt")));
            bool alumnoInsertado = false;
            foreach (var line in File.ReadAllLines(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt")))
            {
                if (line.Contains("1") && line.Contains("Leia") && line.Contains("Organa") && line.Contains("1234"))
                {
                    alumnoInsertado = true;
                    break;
                }
            }
            Assert.IsTrue(alumnoInsertado);
        }
    }
}