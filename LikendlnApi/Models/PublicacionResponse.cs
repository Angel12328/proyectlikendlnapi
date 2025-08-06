using System;
using System.Collections.Generic;

namespace LikendlnApi.Models
{
    public class PublicacionResponse
    {
        public int? IdCandidato { get; set; }
        public int? IdEmpresa { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string NombreCandP { get; set; }
        public string ApellidoCandP { get; set; }
        public string TituloProfesionalCandP { get; set; }
        public string NombreEmpP { get; set; }
        public string ImagenPerfilCandP { get; set; }
        public string ImagenPerfilEmpP { get; set; }
        public string ImagenPublicacion { get; set; }


        // Propiedades adicionales para la respuesta
        public int? CantidadMeGusta { get; set; }
        public int? CantidadComentarios { get; set; }
        public int? CantidadCompartidos { get; set; }
        public List<ComentarioResponse> Comentarios { get; set; }
        public PublicacionResponse()
        {
            Comentarios = new List<ComentarioResponse>();
        }
    }
}