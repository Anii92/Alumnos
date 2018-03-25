using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alumnos.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alumnos.Enums.TiposFichero;

namespace Alumnos.Factories.Tests
{
    [TestClass()]
    public class FicheroFactoryTests
    {
        [DataRow(TipoFichero.Texto, "MiPrimerFicheroTxt.txt")]
        [DataRow(TipoFichero.Json, "MiPrimerFicheroTxt.json")]
        [DataTestMethod]
        public void CrearFicheroTest(TipoFichero tipo, string nombre)
        {

            Assert.Fail();
        }
    }
}