using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Dto_Candidato
{
    public class CrearExperienciaLaboralDto
    {
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }   // si manejas “actual”, puedes permitir null y tratarlo en el servidor
        public string Descripcion { get; set; }
    }
}