using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class SCMiRedRequest
    {
       public int IdCandidatoSeguido { get; set; } // Identificador del candidato que se va a seguir
       public int IdCandidtoSeguidor { get; set; } // Identificador del candidato que está siguiendo

    }
}