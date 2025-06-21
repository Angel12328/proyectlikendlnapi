using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public abstract class Persona
    {
        //  Propiedades
        public string  Nombre { get; set; }
        public string Apellido { get; set; }
        public string CoreoElectronico { get; set; }
        public string Telefono { get; set; }


       // Constructor por defecto
        public Persona()
        {
        }
        //Constructor que recibe todos los parametros
        public Persona(string nombre, string apellido, string coreoElectronico, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            CoreoElectronico = coreoElectronico;
            Telefono = telefono;
        }
        //Metodo ToString
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Apellido: {Apellido}, Correo Electronico: {CoreoElectronico}, Telefono: {Telefono}";
        }

    }
}
