using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class Usuario
    {
        //propiedades
        public int ID { get; set; } // Identificador único del usuario
        public string ContrasenIa { get; set; } // Contraseña del usuario

        public ICollection<Empresa> Empresas { get; set; } // Colección de empresas asociadas al usuario

        //Constructor por defecto
        public Usuario()
        {
        }

        // Constructor que recibe todos los parámetros
        public Usuario(int id, string contrasenIa, ICollection<Empresa> empresas)
        {
            ID = id;
            ContrasenIa = contrasenIa;
            Empresas = empresas;
        }
    }
}
