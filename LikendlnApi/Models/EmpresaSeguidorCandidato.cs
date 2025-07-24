using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class EmpresaSeguidorCandidato
    {
        public int Id { get; set; } // Identificador único de la relación
        public int IdEmpresa { get; set; } // Identificador de la empresa que es seguida
        public virtual Empresa Empresa { get; set; } // Empresa que es seguida
        public int IdCandidato { get; set; } // Identificador del candidato que sigue a la empresa
        public virtual Candidato Candidato { get; set; } // Candidato que sigue a la empresa
        // Constructor por defecto
        public EmpresaSeguidorCandidato()
        {
        }
        // Constructor que recibe todos los parámetros
        public EmpresaSeguidorCandidato(int id, int idEmpresa, Empresa empresa, int idCandidato, Candidato candidato)
        {
            Id = id;
            IdEmpresa = idEmpresa;
            Empresa = empresa;
            IdCandidato = idCandidato;
            Candidato = candidato;
        }   
    }
}