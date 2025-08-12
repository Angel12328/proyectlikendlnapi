using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Dto_Candidato
{
    public class ExperienciaLaboralDto
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }

        // Campos calculados para la vista
        public bool Actual => FechaFin == DateTime.MinValue || FechaFin > DateTime.Now;
        public string Duracion { get; set; }

        // Constructor por defecto
        public ExperienciaLaboralDto()
        {
        }
        // Constructor que recibe todos los parámetros

    }
}