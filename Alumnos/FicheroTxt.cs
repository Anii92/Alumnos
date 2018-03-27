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

        public string ToString(Alumno alumno)
        {
            return alumno.Id + "," + alumno.Nombre + "," + alumno.Apellidos + "," + alumno.Dni + "," + alumno.Alumno_Guid;
        }

        public void Guardar(Alumno alumno)
        {
            if (!File.Exists(this.Ruta))
            {
                using (StreamWriter sw = File.CreateText(this.Ruta))
                {
                    sw.WriteLine(ToString(alumno));
                }
            }
            else
            {
                File.AppendAllText(this.Ruta, ToString(alumno) + Environment.NewLine);
            }
        }
    }
}
