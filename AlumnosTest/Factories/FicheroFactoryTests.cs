using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alumnos.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alumnos.Enums.TiposFichero;
using Alumnos.Interfaces;

namespace Alumnos.Factories.Tests
{
    [TestClass()]
    public class FicheroFactoryTests
    {
        FicheroFactory ficheroFactory = new FicheroFactory();

        [DataRow(TipoFichero.Texto, "MiPrimerFicheroTxt.txt")]
        [DataRow(TipoFichero.Json, "MiPrimerFicheroTxt.json")]
        [DataTestMethod]
        public void CrearFicheroTest(TipoFichero tipo, string nombre)
        {
            IFichero fichero = (IFichero) ficheroFactory.CrearFichero(tipo, nombre);
            switch(tipo)
            {
                case TipoFichero.Json:
                    Assert.IsTrue(fichero.GetType() == typeof(FicheroJson));
                    break;
                case TipoFichero.Texto:
                    Assert.IsTrue(fichero.GetType() == typeof(FicheroTxt));
                    break;
            }
        }
    }
}