using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Interfaces
{
    public interface IFichero
    {
        string Nombre { get; set; }
        string Ruta { get; set; }

        void Guardar(Alumno alumno);
    }
}
