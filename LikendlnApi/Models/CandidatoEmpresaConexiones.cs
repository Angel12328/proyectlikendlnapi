using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class CandidatoEmpresaConexiones
    {
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public Candidato Candidato { get; set; } // Candidato asociado a la conexión
        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; } // Empresa asociada a la conexión

        // Constructor por defecto
        public CandidatoEmpresaConexiones()
        {
        }
        // Constructor que recibe todos los parámetros
        public CandidatoEmpresaConexiones(int id, int idCandidato, Candidato candidato, int idEmpresa, Empresa empresa)
        {
            Id = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdEmpresa = idEmpresa;
            Empresa = empresa;
        }
    }
}