using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.DtoEmpresa
{
    public class CrearEmpresaDto
    {
        public int IdUsuario { get; set; }
        public string NombreEmpresa { get; set; }
        public string Correo { get; set; }
        public string SitioWeb { get; set; }
        public string Descripcion { get; set; }
    }
}