using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
    public class Fichero
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public string Extension { get; set; }

        public Fichero(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
            this.Extension = ConfigurationManager.AppSettings["ExtensionFichero"];
        }
    }
}
