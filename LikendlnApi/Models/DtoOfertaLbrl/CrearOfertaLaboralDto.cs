using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.DtoOfertaLbrl
{
    public class CrearOfertaLaboralDto
    {
        public int IdEmpresa { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string TipoContrato { get; set; }
        public double SalarioMin { get; set; }
        public double SalarioMax { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool Disponible { get; set; }
    }
}