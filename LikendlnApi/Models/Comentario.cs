using LikendlnApi.Models.Data;
using System;

namespace LikendlnApi.Models
{
    public class Comentario
    {
        public int ID { get; set; } // Identificador único del comentario
        public string Texto { get; set; } // Texto del comentario
        public DateTime Fecha { get; set; } // Fecha y hora en que se realizó el comentario
        public int IdCandidato { get; set; } // Identificador del candidato que realizó el comentario (si aplica)
        public Candidato AutorCandidato { get; set; } // Candidato que realizó el comentario (si aplica)
        public int IdEmpresa { get; set; } // Identificador de la empresa que realizó el comentario (si aplica)
        public Empresa AutorEmpresa { get; set; } // Empresa que realizó el comentario (si aplica)
        public int IdPublicacion { get; set; } // Identificador de la publicación a la que pertenece el comentario

        public Publicacion Publicacion { get; set; } // Publicación a la que pertenece el comentario

      // Constructor por defecto
        public Comentario()
        {
        }
        // Constructor que recibe todos los parámetros
        public Comentario(int id, string texto, DateTime fecha, int idCandidato, Candidato autorCandidato, int idEmpresa, Empresa autorEmpresa, int idPublicacion, Publicacion publicacion)
        {
            ID = id;
            Texto = texto;
            Fecha = fecha;
            IdCandidato = idCandidato;
            AutorCandidato = autorCandidato;
            IdEmpresa = idEmpresa;
            AutorEmpresa = autorEmpresa;
            IdPublicacion = idPublicacion;
            Publicacion = publicacion;
        }

    }
}
