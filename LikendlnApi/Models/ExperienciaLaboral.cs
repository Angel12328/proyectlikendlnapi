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
        public Candidato Candidato { get; set; } // Candidato asociado a la experiencia laboral
        public string Cargo { get; set; } // Cargo o puesto desempeñado
        public DateTime FechaInicio { get; set; } // Fecha de inicio de la experiencia laboral
        public DateTime FechaFin { get; set; } 
        public string Descripcion { get; set; } 



    }
}
