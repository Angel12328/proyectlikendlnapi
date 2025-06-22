using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class Publicacion
    {
        private int _id;
        private string _contenido;
        private DateTime _fechaPublicacion;
        private Candidato _autorCandidato;
        private Empresa _autorEmpresa;
        private List<Comentario> _comentarios;

        // Propiedades
        public int Id { get; set; }
        public int IdCandidato { get; set; }
        public Candidato Candidato { get; set; }

        public int IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Candidato AutorCandidato { get; set; }
        public Empresa AutorEmpresa { get; set; }
        public List<Comentario> Comentarios { get; set; }

        // Constructor por defecto
        public Publicacion() { }

        // Constructor que recibe todos los parámetros
        public Publicacion(int id, string contenido, DateTime fechaPublicacion, Candidato autorCandidato, Empresa autorEmpresa, List<Comentario> comentarios)
        {
            Id = id;
            Contenido = contenido;
            FechaPublicacion = fechaPublicacion;
            AutorCandidato = autorCandidato;
            AutorEmpresa = autorEmpresa;
            Comentarios = comentarios;
        }

        // Método ToString
        public override string ToString()
        {
            return $"Id: {Id}, Contenido: {Contenido}, Fecha de Publicación: {FechaPublicacion.ToShortDateString()}, Autor Candidato: {AutorCandidato?.ToString() ?? "N/A"}, Autor Empresa: {AutorEmpresa?.ToString() ?? "N/A"}, Comentarios: {Comentarios.Count}";



        }


    }
}
