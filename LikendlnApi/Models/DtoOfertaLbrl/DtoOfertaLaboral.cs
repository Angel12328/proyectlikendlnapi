using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.DtoOfertaLbrl
{
    public class DtoOfertaLaboral
    {
        public int ID { get; set; }
        public string NombreEmpresa { get; set; }
        public string Titulo { get; set; }
        public string Ubicacion { get; set; }
        public string TipoContrato { get; set; }
        public double SalarioMin { get; set; }
        public double SalarioMax { get; set; }
        public string Descripcion { get; set; }
       



    }
}