using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class FeedResponse
    {
        public int? IdCandidato { get; set; }
        public string Nombre { get; set; }
        public string Apellido{ get; set; }
        public string TituloProfesional { get; set; }

        public string ImagenPerfil { get; set; }

        public List<PublicacionResponse> Publicaciones { get; set; }
        public FeedResponse()
        {
            Publicaciones = new List<PublicacionResponse>();
        }
    }
}