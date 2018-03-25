using Alumnos.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
    public class FicheroTxt : IFichero
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroTxt(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
            // This text is added only once to the file.
            if (!File.Exists(this.Ruta))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(this.Ruta))
                {
                    sw.WriteLine(alumno.Id + "," + alumno.Nombre + "," + alumno.Apellidos + "," + alumno.Dni);
                }
            }
            else
            {
                File.AppendAllText(this.Ruta, alumno.Id + "," + alumno.Nombre + "," + alumno.Apellidos + "," + alumno.Dni + Environment.NewLine);
            }
        }
    }
}
