using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Dto_Candidato
{
    public class CandidatoProfileHeaderDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
        public string CoreoElectronico { get; set; }
        public string Telefono { get; set; }

        public string TituloProfesional { get; set; }
        public string FotoPerfil { get; set; }
        public string CurriculumVitae { get; set; }

        public int Seguidores { get; set; }
        public int TotalPublicaciones { get; set; }

        // Métricas extra por si las quieres mostrar
        public int TotalCursos { get; set; }
        public int TotalExperiencias { get; set; }
        public int TotalHabilidades { get; set; }
    }
}