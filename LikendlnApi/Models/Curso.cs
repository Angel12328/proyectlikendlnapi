using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class Curso
    {
        public int Id { get; set; } // Identificador único del curso
        public int IdCandidato { get; set; } // Identificador del candidato al que pertenece el curso
        public Candidato Candidato { get; set; } // Candidato asociado al curso
        public string Nombre { get; set; } // Nombre del curso

        public string Descripcion { get; set; } // Descripción del curso

        public DateTime FechaInicio { get; set; } // Fecha de inicio del curso
        public DateTime FechaFin { get; set; } // Fecha de finalización del curso

        public string Institucion { get; set; } // Institución que ofrece el curso

        public int IdCredencial { get; set; } // Identificador de la credencial asociada al curso

        public string UrlCertificado { get; set; } // URL del certificado del curso

        // Constructor por defecto
        public Curso()
        {
        }
        // Constructor que recibe todos los parámetros
        public Curso(int id, int idCandidato, Candidato candidato, string nombre, string descripcion, DateTime 
            fechaInicio, DateTime fechaFin, string institucion, int idCredencial, string urlCertificado)
        {
            Id = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            Nombre = nombre;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Institucion = institucion;
            IdCredencial = idCredencial;
            UrlCertificado = urlCertificado;




        }
    }
}