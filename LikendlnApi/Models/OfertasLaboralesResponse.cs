using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class OfertasLaboralesResponse
    {
        public int IdEmpleo { get; set; }
        public string Titulo { get; set; }
        public string Empresa { get; set; }
        public string Ubicacion { get; set; }
        public double SalarioMin { get; set; }
        public double SalarioMax { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string TipoContrato { get; set; }
        public List<HabilidadResponse> HabilidadesRequeridas { get; set; }
        public int CantidadPostulaciones { get; set; }
        public OfertasLaboralesResponse()
        {
            HabilidadesRequeridas = new List<HabilidadResponse>();
        }
    }

    // Contructor por defecto


}