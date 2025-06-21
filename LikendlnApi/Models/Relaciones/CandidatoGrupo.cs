using LikendlnApi.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Relaciones
{
    public class CandidatoGrupo
    {
        //properties
        public int ID { get; set; } // Identificador único de la relación
        public int IdCandidato { get; set; } // Identificador del candidato
        public Candidato Candidato { get; set; } // Candidato asociado al grupo
        public int IdGrupo { get; set; } // Identificador del grupo
        public Grupo Grupo { get; set; } // Grupo asociado al candidato

        // Constructor por defecto
        public CandidatoGrupo()
        {
        }
        // Constructor que recibe todos los parámetros
        public CandidatoGrupo(int id, int idCandidato, Candidato candidato, int idGrupo, Grupo grupo)
        {
            ID = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdGrupo = idGrupo;
            Grupo = grupo;
        }


    }
}