using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class MiRedResponse
    {
        public List<MiRedDataCCCResponse> CandidatosConexiones { get; set; }
        public List<MiRedDataCECResponse> EmpresasConexiones { get; set; }

        public MiRedResponse()
        {
            CandidatosConexiones = new List<MiRedDataCCCResponse>();
            EmpresasConexiones = new List<MiRedDataCECResponse>();
        }
    }
}