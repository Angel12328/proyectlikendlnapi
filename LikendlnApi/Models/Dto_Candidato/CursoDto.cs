using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Dto_Candidato
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Institucion { get; set; }
        public string UrlCertificado { get; set; }

        // Campos para UI
        public string Duracion { get; set; }
    }
}