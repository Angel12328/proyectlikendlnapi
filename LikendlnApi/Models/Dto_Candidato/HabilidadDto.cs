using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Dto_Candidato
{
    public class HabilidadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Nivel { get; set; } // Básico, Intermedio, Avanzado
    }
}