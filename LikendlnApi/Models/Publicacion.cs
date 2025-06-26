using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class Publicacion
    {
       

        // Propiedades
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public Candidato Candidato { get; set; }

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public int IdGrupo { get; set; } // Id del grupo al que pertenece la publicación, si es que pertenece a uno
        public Grupo Grupo { get; set; } // Objeto del grupo al que pertenece la publicación, si es que pertenece a uno
        public string Contenido { get; set; }
        public DateTime FechaPublicacion { get; set; }
     
        public List<Comentario> Comentarios { get; set; }

        public string ImagenURL { get; set; } // Imagen de la publicación, si es que tiene

        // Constructor por defecto
        public Publicacion() { }


        // Constructor que recibe todos los parámetros  
        public Publicacion(int id, int idCandidato, Candidato candidato, int idEmpresa, Empresa empresa, int idGrupo, Grupo grupo,
            string contenido, DateTime fechaPublicacion, List<Comentario> comentarios, string imagenURL)
        {
            Id = id;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdEmpresa = idEmpresa;
            Empresa = empresa;
            IdGrupo = idGrupo;
            Grupo = grupo;
            Contenido = contenido;
            FechaPublicacion = fechaPublicacion;
            Comentarios = comentarios;
            ImagenURL = imagenURL;
        }

       



    }
}
