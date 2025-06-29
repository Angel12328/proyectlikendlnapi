
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class CandidatoHabilidad
    {
        //properties
        public int ID { get; set; } // Identificador único de la relación
        public int IdCandidato { get; set; } // Identificador del candidato
        public Candidato Candidato { get; set; } // Candidato asociado a la habilidad
        public int IdHabilidad { get; set; } // Identificador de la habilidad
        public Habilidad Habilidad { get; set; } // Habilidad asociada al candidato
        // Constructor por defecto
        public CandidatoHabilidad()
        {
        }
        // Constructor que recibe todos los parámetros
        public CandidatoHabilidad(int id, int idCandidato, Candidato candidato, int idHabilidad, Habilidad habilidad)
        {
            ID = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdHabilidad = idHabilidad;
            Habilidad = habilidad;
        }
    }
}