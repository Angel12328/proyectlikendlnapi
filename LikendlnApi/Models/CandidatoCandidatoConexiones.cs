using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class CandidatoCandidatoConexiones
    {
        //cambio heho por angelproyecto
        public int ID { get; set; } // Identificador único de la relación
        public int IdCandidato { get; set; }
        public Candidato Candidato { get; set; } // Candidato que inicia la relación
        public int IdCandidatoConexion { get; set; }
        public Candidato CandidatoConexion { get; set; } // Candidato que recibe la relación


        //constructor por defecto
        public CandidatoCandidatoConexiones()
        {
        }
        // Constructor que recibe todos los parámetros
        public CandidatoCandidatoConexiones(int id, int idCandidato, Candidato candidato, int idCandidatoConexion, Candidato candidatoConexion)
        {
            ID = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdCandidatoConexion = idCandidatoConexion;
            CandidatoConexion = candidatoConexion;

        }
    }
}