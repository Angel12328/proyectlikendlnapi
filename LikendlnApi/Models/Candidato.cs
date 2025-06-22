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
        public int Seguidores { get; set; } //numero de seguidores del candidato


        public List<Publicacion> ListPublicaciones { get; set; } = new List<Publicacion>();//lista de publicaciones del candidato
        
        //Icollection uno a muchos
        public ICollection<ExperienciaLaboral> ExperienciasLaborales { get; set; } //coleccion  de experiencias laborales del candidato
        public ICollection<Publicacion> Publicaciones { get; set; } //coleccion de publicaciones del candidato
        //>> una coleccion de cursos del candidato


        //Icollection uno a muchos
        public ICollection<CandidatoOfertaLaboral> CandidadtosOfertas { get; set; }
        public ICollection<CandidatoGrupo> CandidadtosGrupos { get; set; }
        public ICollection<CandidatoHabilidad> CandidatosHabilidades { get; set; } // Relación con habilidades
        public ICollection<CandidatoCandidatoConexiones> CandidatosConexiones { get; set; } // Relación con habilidades
        public ICollection<CandidatoEmpresaConexiones> CandidatosEmpresasConexiones { get; set; } // Relación con empresas
        //>> una coleccion de candidatos seguidores del candidato
        //>> una coleccion de empresas seguidores del candidato

        // Constructor por defecto
        public Candidato()
        {
        }
        // Constructor que recibe todos los parámetros
        








    }
}
