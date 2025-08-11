using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class Habilidad
    {
        //  propiedades
        public int ID { get; set; } // Identificador único de la habilidad
        public string Nombre { get; set; } 
        public string Descripcion { get; set; } 
        public string Categoria { get; set; } 
        public string Nivel { get; set; } // Nivel de habilidad (por ejemplo, "Básico", "Intermedio", "Avanzado")

        //relacion muchos a muchos
        
        public virtual ICollection<OfertaLaboralHabilidad> HabilidadesRequeridas { get; set; }
        // Constructor por defecto
        public Habilidad()
        {
        }
        
        // Constructor que recibe todos los parámetros
        public Habilidad(int id, string nombre, string descripcion, string categoria, string nivel)
        {
            ID = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            Nivel = nivel;
        }




    }
}
