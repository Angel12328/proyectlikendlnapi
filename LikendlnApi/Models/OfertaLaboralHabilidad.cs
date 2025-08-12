using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class OfertaLaboralHabilidad
    {
        public int ID { get; set; } // Identificador único de la relación   
        public int IdOfertaLaboral { get; set; } // Identificador de la oferta laboral
        public virtual OfertaLaboral OfertaLaboral { get; set; } // Oferta laboral asociada a la habilidad
        public int IdHabilidad { get; set; } // Identificador de la habilidad
        public virtual Habilidad Habilidad { get; set; } // Habilidad asociada a la oferta laboral

        // Constructor por defecto
        public OfertaLaboralHabilidad()
        {
        }
        // Constructor que recibe todos los parámetros
        public OfertaLaboralHabilidad(int id, int idOfertaLaboral, OfertaLaboral ofertaLaboral, int idHabilidad, Habilidad habilidad)
        {
            ID = id;
            IdOfertaLaboral = idOfertaLaboral;
            OfertaLaboral = ofertaLaboral;
            IdHabilidad = idHabilidad;
            Habilidad = habilidad;
        }
    }
}