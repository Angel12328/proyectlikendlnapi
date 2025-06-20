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
        public int Id { get { return _id; } set { _id = value; } }
        public string Contenido { get { return _contenido; } set { _contenido = value; } }
        public DateTime FechaPublicacion { get { return _fechaPublicacion; } set { _fechaPublicacion = value; } }
        public Candidato AutorCandidato { get { return _autorCandidato; } set { _autorCandidato = value; } }
        public Empresa AutorEmpresa { get { return _autorEmpresa; } set { _autorEmpresa = value; } }
        public List<Comentario> Comentarios { get { return _comentarios; } set { _comentarios = value; } }

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
