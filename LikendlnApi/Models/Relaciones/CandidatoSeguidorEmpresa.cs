using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Relaciones
{
    public class CandidatoSeguidorEmpresa
    {
        public int Id { get; set; } // Identificador único de la relación
        public int IdCandidato { get; set; } 
        public Candidato Candidato { get; set; } 
        public int IdEmpresa { get; set; } 
        public Empresa Empresa { get; set; } 

        // Constructor por defecto
        public CandidatoSeguidorEmpresa()
        {
        }
        // Constructor que recibe todos los parámetros
        public CandidatoSeguidorEmpresa(int id, int idCandidato, Candidato candidato, int idEmpresa, Empresa empresa)
        {
            Id = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdEmpresa = idEmpresa;
            Empresa = empresa;
        }
    }
}