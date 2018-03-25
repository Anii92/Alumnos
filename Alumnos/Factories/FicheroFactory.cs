using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Alumnos.Enums.TiposFichero;

namespace Alumnos.Factories
{
    public class FicheroFactory
    {
        public Object CrearFichero(TipoFichero tipoFichero, string nombre)
        {
            switch (tipoFichero)
            {
                case TipoFichero.Texto:
                    return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
                case TipoFichero.Json:
                    return new FicheroJson(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.json"));
                default:
                    return new FicheroTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.txt"));
            }
        }
    }
}
