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
        public Usuario Usuario { get; set; }//usuario del candidato
        public string TituloProfesional { get; set; }  //tituo profesional del candidato
        public string CurriculumVitae { get; set; }//curriculum vitae del candidato
        public List<Habilidad> ListHabilidades { get; set; } = new List<Habilidad>();//lista de habilidades del candidato
        public List<ExperienciaLaboral> ListexperienciasLaborales { get; set; } = new List<ExperienciaLaboral>();//lista de experiencias laborales del candidato
        public List<OfertaLaboral> ListOfertasPostuladas { get; set; } = new List<OfertaLaboral>();//lista de ofertas laborales a las que el candidato se ha postulado
        public List<Usuario> ListConexiones { get; set; } = new List<Usuario>();//lista de usuarios que el candidato sigue 
        public List<Grupo> ListGrupos { get; set; } = new List<Grupo>();//lista de grupos a los que el candidato pertenece
        public List<Publicacion> ListPublicaciones { get; set; } = new List<Publicacion>();//lista de publicaciones del candidato



        //Constructor por defecto
        public Candidato()
        {
        }

       //Constructor que recibe todos los parametros
        public Candidato(int id, Usuario usuario, string tituloProfesional, string curriculumVitae, List<Habilidad> listHabilidades, 
            List<ExperienciaLaboral> listexperienciasLaborales, List<OfertaLaboral> listOfertasPostuladas, List<Usuario> listConexiones, List<Grupo> listGrupos, List<Publicacion> listPublicaciones)
        {
            Id = id;
            Usuario = usuario;
            TituloProfesional = tituloProfesional;
            CurriculumVitae = curriculumVitae;
            ListHabilidades = listHabilidades;
            ListexperienciasLaborales = listexperienciasLaborales;
            ListOfertasPostuladas = listOfertasPostuladas;
            ListConexiones = listConexiones;
            ListGrupos = listGrupos;
            ListPublicaciones = listPublicaciones;
        }


        //Metodo ToString
        public override string ToString()
        {
            return $"Id: {Id}, Usuario: {Usuario}, Titulo Profesional: {TituloProfesional}, Curriculum Vitae: {CurriculumVitae}";
        }





    }
}
