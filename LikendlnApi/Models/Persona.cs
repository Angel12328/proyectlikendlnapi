using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public abstract class Persona
    {
        //Atributos
        private string  _nombre;
        private string  _apellido;
        private string _coreoElectronico;
        private string _telefono;


        //Constructor por defecto
        protected Persona()
        {
        }

        //Constructor que recibe todos los parametros
        protected Persona(string nombre, string apellido, string coreoElectronico, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            CoreoElectronico = coreoElectronico;
            Telefono = telefono;
        }

        //setters y getters
        public string Nombre { 
            get { return _nombre; } 
            set { _nombre = value; }
        }
        public string Apellido {
            get { return _apellido; }
            set { _apellido = value; } 
        }
        public string CoreoElectronico { 
            
            get { return _coreoElectronico; }
            set { _coreoElectronico = value; }
        
        }
        public string Telefono { 
            get { return _telefono; }
            set { _telefono = value; }
        }

        //Metodo ToString
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
