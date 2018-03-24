using Alumnos.Factories;
using Alumnos.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alumnos.Enums.TiposFichero;
using static Alumnos.Enums.TiposPersona;

namespace Alumnos
{
    public class AlumnoController
    {
        private IFichero fichero;
        private FicheroFactory ficheroFactory;

        public void CrearAlumno()
        {
            Alumno alumno = CrearNuevoAlumno();

            TipoFichero opcion;
            Enum.TryParse<TipoFichero>(ConfigurationManager.AppSettings[Alumnos.Configuracion.ExtensionFichero], out opcion);
            fichero = (IFichero) FicheroFactory.CrearFichero(opcion, "ListadoAlumnos");
            //switch (opcion)
            //{
            //    case TipoFichero.Texto:
            //        fichero = new FicheroTxt("ListadoAlumnos", System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
            //        break;
            //    case TipoFichero.Json:
            //        fichero = new FicheroJson("ListadoAlumnos", System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
            //        break;
            //}
            fichero.Guardar(alumno);
            Console.WriteLine("El alumno se ha creado correctamente");
        }

        public static Alumno CrearNuevoAlumno()
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
            Alumno alumno = (Alumno)PersonaFactory.CrearPersona(TipoPersona.Alumno, Convert.ToInt32(idAlumno), idNombre, idApellidos, idDni);
            //Alumno a = new Alumno(Convert.ToInt32(idAlumno), idNombre, idApellidos, idDni);
            return alumno;
        }
    }
}
