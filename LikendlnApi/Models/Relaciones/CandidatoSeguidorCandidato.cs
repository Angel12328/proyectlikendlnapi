using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Relaciones
{
    public class CandidatoSeguidorCandidato
    {
        public int Id { get; set; } // Identificador único de la relación
        public int IdCandidato { get; set; } // Identificador del candidato que es seguido
        public Candidato Candidato { get; set; } // Candidato que es seguido
        public int IdSeguidor { get; set; } // Identificador del seguidor (otro candidato)
        public Candidato Seguidor { get; set; } // Candidato que sigue al otro candidato
        // Constructor por defecto
        public CandidatoSeguidorCandidato()
        {
        }
        // Constructor que recibe todos los parámetros
        public CandidatoSeguidorCandidato(int id, int idCandidato, Candidato candidato, int idSeguidor, Candidato seguidor)
        {
            Id = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdSeguidor = idSeguidor;
            Seguidor = seguidor;
        }
    }
}