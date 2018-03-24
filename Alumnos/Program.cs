using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Alumnos.Enums.TiposPersona;

namespace Alumnos
{
    class Program
    {
        private static AlumnoController alumnoController;
        private static ConfiguracionController configuracionController;

        private enum Opciones
        {
            Crear,
            Opciones,
            Salir
        };

        private static void MostrarOpciones()
        {
            Console.WriteLine("0.Crear alumno");
            Console.WriteLine("1.Configuraciones");
            Console.WriteLine("2.Salir");
        }

        private static void Init()
        {
            configuracionController = new ConfiguracionController();
            alumnoController = new AlumnoController();
        }

        private static void OpcionesMenu()
        {
            bool exit = false;
            while (!exit)
            {
                MostrarOpciones();
                ConsoleKeyInfo opcionKey = Console.ReadKey();
                Console.WriteLine();
                Opciones opcion;
                string opcionString = (opcionKey.KeyChar).ToString();
                Enum.TryParse<Opciones>(opcionString, out opcion);
                switch (opcion)
                {
                    case Opciones.Crear:
                        alumnoController.CrearAlumno();
                        break;
                    case Opciones.Opciones:
                        configuracionController.OpcionesConfiguracion();
                        break;
                    case Opciones.Salir:
                        exit = true;
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Init();
            OpcionesMenu();
        }
    }
}
