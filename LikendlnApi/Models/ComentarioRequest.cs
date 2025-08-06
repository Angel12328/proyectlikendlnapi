using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class ComentarioRequest
    {

        public int IdPublicacion { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdCandidato { get; set; } 
        public string  Comentario { get; set; }

    }
}