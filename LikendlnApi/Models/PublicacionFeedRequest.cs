using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class PublicacionFeedRequest
    {
        public int IdCandidato { get; set; }        
        public string Contenido { get; set; }
        
        public string ImagenURL { get; set; }
    }
}