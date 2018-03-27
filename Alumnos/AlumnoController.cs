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
        private PersonaFactory personaFactory;

        public AlumnoController()
        {
            ficheroFactory = new FicheroFactory();
            personaFactory = new PersonaFactory();
        }

        public void CrearAlumno()
        {
            Alumno alumno = CrearNuevoAlumno();

            TipoFichero opcion;
            Enum.TryParse<TipoFichero>(ConfigurationManager.AppSettings[Alumnos.Configuracion.ExtensionFichero], out opcion);
            fichero = (IFichero) ficheroFactory.CrearFichero(opcion, "ListadoAlumnos");
            fichero.Guardar(alumno);
            Console.WriteLine("El alumno se ha creado correctamente");
        }

        public Alumno CrearNuevoAlumno()
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
            Alumno alumno = (Alumno)personaFactory.CrearPersona(TipoPersona.Alumno, Convert.ToInt32(idAlumno), idNombre, idApellidos, idDni);
            return alumno;
        }
    }
}
