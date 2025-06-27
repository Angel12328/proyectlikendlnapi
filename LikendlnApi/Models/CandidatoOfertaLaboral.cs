
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class CandidatoOfertaLaboral
    {
        //  properties
        public int ID { get; set; } // Identificador único de la relación
        public int IdCandidato { get; set; } // Identificador del candidato
        public Candidato Candidato { get; set; } // Candidato asociado a la oferta laboral
        public int IdOfertaLaboral { get; set; } // Identificador de la oferta laboral
        public OfertaLaboral OfertaLaboral { get; set; } // Oferta laboral asociada al candidato
        // Constructor por defecto
        public CandidatoOfertaLaboral()
        {
        }
        // Constructor que recibe todos los parámetros
        public CandidatoOfertaLaboral(int id, int idCandidato, Candidato candidato, int idOfertaLaboral, OfertaLaboral ofertaLaboral)
        {
            ID = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdOfertaLaboral = idOfertaLaboral;
            OfertaLaboral = ofertaLaboral;
        }
    }
}