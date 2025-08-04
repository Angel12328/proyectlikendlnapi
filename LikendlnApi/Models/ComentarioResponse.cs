using System;

namespace LikendlnApi.Models
{
    public class ComentarioResponse
    {
        public int IdCandidato { get; set; }
        public int IdEmpresa { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaComentario { get; set; }
        public string NombreAutor { get; set; }
        public string ApellidoAutor { get; set; }
        public string NombreEmpresaAutor { get; set; }
        public string ImagenPerfilAutorCand { get; set; }
        public string ImagenPerfilAutorEmp { get; set; }




    }
}