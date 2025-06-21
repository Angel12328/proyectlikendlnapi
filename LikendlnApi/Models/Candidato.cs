using LikendlnApi.Models.Data;
using LikendlnApi.Models.Relaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class Candidato : Persona
    {
        //Propiedades
        public int  Id { get; set; }//id del candidato
        public int IdUsuario { get; set; } //id del usuario del candidato
        public Usuario Usuario { get; set; }//usuario del candidato
        public string TituloProfesional { get; set; }  //tituo profesional del candidato
        public string CurriculumVitae { get; set; }//curriculum vitae del candidato
        public List<Habilidad> ListHabilidades { get; set; } = new List<Habilidad>();//lista de habilidades del candidato
        public List<ExperienciaLaboral> ListexperienciasLaborales { get; set; } = new List<ExperienciaLaboral>();//lista de experiencias laborales del candidato
        public List<Usuario> ListConexiones { get; set; } = new List<Usuario>();//lista de usuarios que el candidato sigue
        public List<Publicacion> ListPublicaciones { get; set; } = new List<Publicacion>();//lista de publicaciones del candidato

        //Icollection 
        public ICollection<CandidatoOfertaLaboral> CandidadtosOfertas { get; set; }
        public ICollection<CandidatoGrupo> CandidadtosGrupos { get; set; }

       // Constructor por defecto
        public Candidato()
        {
        }
        // Constructor que recibe todos los parámetros
        public Candidato(int id, int idUsuario, Usuario usuario, string tituloProfesional, string curriculumVitae,
            List<Habilidad> listHabilidades, List<ExperienciaLaboral> listexperienciasLaborales,
            List<Usuario> listConexiones, List<Publicacion> listPublicaciones)
        {
            Id = id;
            IdUsuario = idUsuario;
            Usuario = usuario;
            TituloProfesional = tituloProfesional;
            CurriculumVitae = curriculumVitae;
            ListHabilidades = listHabilidades;
            ListexperienciasLaborales = listexperienciasLaborales;
            ListConexiones = listConexiones;
            ListPublicaciones = listPublicaciones;
        }







    }
}
