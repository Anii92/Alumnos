using Microsoft.VisualStudio.TestTools.UnitTesting;
using Alumnos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Alumnos.Tests
{
    [TestClass()]
    public class ConfiguracionControllerTests
    {
        ConfiguracionController configuracionController = new ConfiguracionController();

        [DataRow("Texto")]
        [DataRow("Json")]
        [DataTestMethod()]
        public void GuardarConfiguracionTest(string extensionFichero)
        {
            configuracionController.GuardarConfiguracion(extensionFichero);
            Assert.IsTrue(extensionFichero == ConfigurationManager.AppSettings[Alumnos.Configuracion.ExtensionFichero]);
        }

        [DataRow("Texto")]
        [DataTestMethod()]
        public void CrearConfiguracionFicheroTest(string valor)
        {
            configuracionController.CrearConfiguracionFichero(valor);
            Assert.IsTrue(valor == ConfigurationManager.AppSettings[Alumnos.Configuracion.ExtensionFichero]);
        }
    }
}