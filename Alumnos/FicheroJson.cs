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
                var jsonData = System.IO.File.ReadAllText(this.Ruta);
                // De-serialize to object or create new list
                var employeeList = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);

                // Add any new employees
                employeeList.Add(alumno);

                // Update json data string
                jsonData = JsonConvert.SerializeObject(employeeList, Formatting.Indented);
                System.IO.File.WriteAllText(this.Ruta, jsonData);
            }
        }
    }
}
