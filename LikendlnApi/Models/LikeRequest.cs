using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class LikeRequest
    {
        public int IdPublicacion { get; set; } 
        public int IdCandidatoLog { get; set; } 
    }
}