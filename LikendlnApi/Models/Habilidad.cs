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
        public int IdCandidato { get; set; } // Identificador del candidato al que pertenece la habilidad
        public Candidato Candidato { get; set; } // Candidato asociado a la habilidad
        public int IdOfertaLaboral { get; set; } // Identificador de la oferta laboral relacionada (opcional)
        public OfertaLaboral OfertaLaboral { get; set; } // Oferta laboral relacionada (opcional)
        public string Nombre { get; set; } 
        public string Descripcion { get; set; } 
        public string Categoria { get; set; } 
        public string Nivel { get; set; } // Nivel de habilidad (por ejemplo, "Básico", "Intermedio", "Avanzado")

        // Constructor por defecto
        public Habilidad()
        {
        }

        // Constructor que recibe todos los parámetros
        public Habilidad(int id, int idCandidato, Candidato candidato, int idOfertaLaboral, OfertaLaboral ofertaLaboral, string nombre, string descripcion, string categoria, string nivel)
        {
            ID = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdOfertaLaboral = idOfertaLaboral;
            OfertaLaboral = ofertaLaboral;
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            Nivel = nivel;
        }



    }
}
