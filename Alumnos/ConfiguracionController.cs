using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alumnos.Enums.TiposFichero;

namespace Alumnos
{
    public class ConfiguracionController
    {
        public ConfiguracionController()
        {
            CrearConfiguracionFichero(".txt");
        }

        public void OpcionesConfiguracion()
        {
            MostrarOpcionesConfiguracion();
            ConsoleKeyInfo opcionKey = Console.ReadKey();
            Console.WriteLine();
            TipoFichero opcion;
            string aux = (opcionKey.KeyChar).ToString();
            Enum.TryParse<TipoFichero>(aux, out opcion);
            switch (opcion)
            {
                case TipoFichero.Texto:
                    GuardarConfiguracion("Texto");
                    break;
                case TipoFichero.Json:
                    GuardarConfiguracion("Json");
                    break;
            }
        }

        private void CrearConfiguracionFichero(string valor)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[Alumnos.Configuracion.ExtensionFichero]))
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Add(Alumnos.Configuracion.ExtensionFichero, valor);
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        public void GuardarConfiguracion(string extensionFichero)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[Alumnos.Configuracion.ExtensionFichero].Value = extensionFichero;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void MostrarOpcionesConfiguracion()
        {
            Console.WriteLine("¿En qué formato quieres serializar el alumno?");
            Console.WriteLine("0.Texto");
            Console.WriteLine("1.Json");
        }
    }
}
