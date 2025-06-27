using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public abstract class Persona
    {
        //  Propiedades
        public int Id { get; set; } // Identificador único de la persona
        public string  Nombre { get; set; }
        public string Apellido { get; set; }
        public string CoreoElectronico { get; set; }
        public string Telefono { get; set; }


       // Constructor por defecto
        public Persona()
        {
        }

        // Constructor que recibe todos los parámetros
        public Persona(int id, string nombre, string apellido, string coreoElectronico, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            CoreoElectronico = coreoElectronico;
            Telefono = telefono;
        }
    }
}
