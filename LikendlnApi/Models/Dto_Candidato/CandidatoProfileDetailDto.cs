using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Dto_Candidato
{
    public class CandidatoProfileDetailDto
    {
        public CandidatoProfileHeaderDto Header { get; set; }


        public List<ExperienciaLaboralDto> Experiencias { get; set; } = new List<ExperienciaLaboralDto>();
        public List<CursoDto> Cursos { get; set; } = new List<CursoDto>();
        public List<HabilidadDto> Habilidades { get; set; } = new List<HabilidadDto>();
        public List<PublicacionResumenDto> PublicacionesRecientes { get; set; } = new List<PublicacionResumenDto>();

    }
}