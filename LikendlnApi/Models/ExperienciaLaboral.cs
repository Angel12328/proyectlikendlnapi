using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class ExperienciaLaboral
    {
        //Atributos
        public int ID { get; set; } // Identificador único de la experiencia laboral
        public string Empresa { get; set; } // Nombre de la empresa donde se trabajó
        public int IdCandidato { get; set; } // Identificador del candidato al que pertenece la experiencia laboral
        public Candidato Candidato { get; set; } // Candidato asociado a la experiencia laboral
        public string Cargo { get; set; } // Cargo o puesto desempeñado
        public DateTime FechaInicio { get; set; } // Fecha de inicio de la experiencia laboral
        public DateTime FechaFin { get; set; } 
        public string Descripcion { get; set; }

        // Constructor por defecto
        public ExperienciaLaboral()
        {
        }
        // Constructor que recibe todos los parámetros

        public ExperienciaLaboral(int id, string empresa, int idCandidato, Candidato candidato, string cargo, DateTime fechaInicio, DateTime fechaFin, string descripcion)
        {
            ID = id;
            Empresa = empresa;
            IdCandidato = idCandidato;
            Candidato = candidato;
            Cargo = cargo;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Descripcion = descripcion;
        }



    }
}
