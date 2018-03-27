using Alumnos.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos
{
    public class FicheroJson: IFichero
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public FicheroJson(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public string ToJson(string data, Alumno alumno)
        {
            var employeeList = JsonConvert.DeserializeObject<List<Alumno>>(data);
            employeeList.Add(alumno);
            return JsonConvert.SerializeObject(employeeList, Formatting.Indented);
        }

        public void Guardar(Alumno alumno)
        {
            if (!File.Exists(this.Ruta))
            {
                List<Alumno> alumnos = new List<Alumno>();
                alumnos.Add(alumno);
                using (StreamWriter file = File.CreateText(this.Ruta))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, alumnos);
                }
            }
            else
            {
                string datosFichero = System.IO.File.ReadAllText(this.Ruta);
                string jsonData = this.ToJson(datosFichero, alumno);
                System.IO.File.WriteAllText(this.Ruta, jsonData);
            }
        }
    }
}
