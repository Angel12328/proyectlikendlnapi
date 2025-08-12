using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Dto_Candidato
{
    public class PublicacionResumenDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string ContenidoResumen { get; set; }
        public int Reacciones { get; set; }
        public int Comentarios { get; set; }
    }
}