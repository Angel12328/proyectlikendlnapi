using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class Recomendacion
    {
        //propiedades
        public int ID { get; set; } // Identificador único de la recomendación
        public int IDCandidato { get; set; } // Identificador del candidato al que se le hace la recomendación
        public Candidato Candidato; // Usuario que hace la recomendación
        public int IdEmpresa { get; set; } // Identificador de la empresa que hace la recomendación
        public Empresa Empresa { get; set; } // Empresa qe hace la recomendación
        public string Mensaje { get; set; } // Mensaje de la recomendación
        public DateTime Fecha { get; set; } // Fecha de la recomendación


     
        public Recomendacion()
        {
        }
        // Constructor que recibe todos los parámetros
        public Recomendacion(int id, int idCandidato, Candidato candidato, int idEmpresa, Empresa empresa, string mensaje, DateTime fecha)
        {
            ID = id;
            IDCandidato = idCandidato;
            Candidato = candidato;
            IdEmpresa = idEmpresa;
            Empresa = empresa;
            Mensaje = mensaje;
            Fecha = fecha;
        }


    }


}
