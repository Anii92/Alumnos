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
        private static Fichero fichero;

        private enum Opciones
        {
            Crear,
            Opciones,
            Salir
        };

        private enum OpcionesConfiguracion
        {
            Texto,
            Json
        };

        private static Alumno CrearNuevoAlumno()
        {
            Console.WriteLine("Crea un alumno");
            Console.WriteLine("Introduce el identificador");
            string idAlumno = Console.ReadLine();
            Console.WriteLine("Introduce el nombre");
            string idNombre = Console.ReadLine();
            Console.WriteLine("Introduce el apellidos");
            string idApellidos = Console.ReadLine();
            Console.WriteLine("Introduce el dni");
            string idDni = Console.ReadLine();
            Alumno alumno = (Alumno) PersonaFactory.CrearPersona(TipoPersona.Alumno, Convert.ToInt32(idAlumno), idNombre, idApellidos, idDni);
            //Alumno a = new Alumno(Convert.ToInt32(idAlumno), idNombre, idApellidos, idDni);
            return alumno;
            
            
        }

        private static void FileTexto(Alumno a)
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "MyTest.txt");
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(a.Id + "," + a.Nombre + "," + a.Apellidos + "," + a.Dni);
                }
            }
            else
            {
                File.AppendAllText(path, a.Id + "," + a.Nombre + "," + a.Apellidos + "," + a.Dni + Environment.NewLine);
            }
        }

        private static void FileJson(Alumno a)
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "MyJson.json");
            if (!File.Exists(path))
            {
                List<Alumno> alumnos = new List<Alumno>();
                alumnos.Add(a);
                using (StreamWriter file = File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, alumnos);
                }
            }
            else
            {
                var jsonData = System.IO.File.ReadAllText(path);
                // De-serialize to object or create new list
                var employeeList = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);

                // Add any new employees
                employeeList.Add(a);

                // Update json data string
                jsonData = JsonConvert.SerializeObject(employeeList, Formatting.Indented);
                System.IO.File.WriteAllText(path, jsonData);
            }
        }

        private static void MostrarOpciones()
        {
            Console.WriteLine("0.Crear alumno");
            Console.WriteLine("1.Configuraciones");
            Console.WriteLine("2.Salir");
        }

        private static void MostrarOpcionesConfiguracion()
        {
            Console.WriteLine("¿En qué formato quieres serializar el alumno?");
            Console.WriteLine("0.Texto");
            Console.WriteLine("1.Json");
        }

        private static void CrearAlumno()
        {
            Alumno alumno = CrearNuevoAlumno();
            OpcionesConfiguracion opcion;
            Enum.TryParse<OpcionesConfiguracion>(fichero.Extension, out opcion);
            switch (opcion)
            {
                case OpcionesConfiguracion.Texto:
                    FileTexto(alumno);
                    break;
                case OpcionesConfiguracion.Json:
                    FileJson(alumno);
                    break;
            }
            Console.WriteLine("El alumno se ha creado correctamente");
        }

        private static void Configuracion()
        {
            MostrarOpcionesConfiguracion();
            ConsoleKeyInfo opcionKey = Console.ReadKey();
            Console.WriteLine();
            OpcionesConfiguracion opcion;
            string aux = (opcionKey.KeyChar).ToString();
            Enum.TryParse<OpcionesConfiguracion>(aux, out opcion);
            switch (opcion)
            {
                case OpcionesConfiguracion.Texto:
                    GuardarConfiguracion(".txt");
                    break;
                case OpcionesConfiguracion.Json:
                    GuardarConfiguracion(".json");
                    break;
            }
        }

        private static void GuardarConfiguracion(string extensionFichero)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[Alumnos.Configuracion.ExtensionFichero].Value = extensionFichero;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private static void Init()
        {
            CrearConfiguracionFichero(".txt");
            InicializarDatosFichero();
        }

        private static void CrearConfiguracionFichero(string valor)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[Alumnos.Configuracion.ExtensionFichero]))
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Add(Alumnos.Configuracion.ExtensionFichero, valor);
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static void InicializarDatosFichero()
        {
            fichero = new Fichero("ListadoDeAlumnos", System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos" + ConfigurationManager.AppSettings[Alumnos.Configuracion.ExtensionFichero]));
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
                string aux = (opcionKey.KeyChar).ToString();
                Enum.TryParse<Opciones>(aux, out opcion);
                switch (opcion)
                {
                    case Opciones.Crear:
                        CrearAlumno();
                        break;
                    case Opciones.Opciones:
                        Configuracion();
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
