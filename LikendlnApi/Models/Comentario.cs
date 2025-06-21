using LikendlnApi.Models.Data;
using System;

namespace LikendlnApi.Models
{
    public class Comentario
    {
        private int _id;
        private string _texto;
        private DateTime _fecha;
        private Candidato _autorCandidato;
        private Empresa _autorEmpresa;
        private Publicacion _publicacion;

        // Propiedades
        public int Id { get { return _id; } set { _id = value; } }
        public string Texto { get { return _texto; } set { _texto = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        public Candidato AutorCandidato { get { return _autorCandidato; } set { _autorCandidato = value; } }
        public Empresa AutorEmpresa { get { return _autorEmpresa; } set { _autorEmpresa = value; } }
        public Publicacion Publicacion { get { return _publicacion; } set { _publicacion = value; } }

        // Constructor por defecto
        public Comentario() { }

        // Constructor que recibe todos los parámetros
        public Comentario(int id, string texto, DateTime fecha, Candidato autorCandidato, Empresa autorEmpresa, Publicacion publicacion)
        {
            Id = id;
            Texto = texto;
            Fecha = fecha;
            AutorCandidato = autorCandidato;
            AutorEmpresa = autorEmpresa;
            Publicacion = publicacion;
        }

        // Método ToString
        public override string ToString()
        {
            return $"Id: {Id}, Texto: {Texto}, Fecha: {Fecha.ToShortDateString()}, Autor Candidato: {AutorCandidato?.ToString() ?? "N/A"}, Autor Empresa: {AutorEmpresa?.ToString() ?? "N/A"}, Publicación: {Publicacion?.ToString() ?? "N/A"}";

        }

    }
}
