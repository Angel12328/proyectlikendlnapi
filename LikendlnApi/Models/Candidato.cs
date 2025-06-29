
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
        //cambio prueba heho por allanproyecto
        //cambio2
        public int IdUsuario { get; set; } //id del usuario del candidato
        public Usuario Usuario { get; set; }//usuario del candidato
        public string TituloProfesional { get; set; }  //tituo profesional del candidato
        public string CurriculumVitae { get; set; }//curriculum vitae del candidato
        public int Seguidores { get; set; } //numero de seguidores del candidato

        public string FotoPerfil { get; set; } //foto de perfil del candidato




        //Icollection uno a muchos
        public ICollection<ExperienciaLaboral> ExperienciasLaborales { get; set; } //coleccion  de experiencias laborales del candidato
        public ICollection<Publicacion> Publicaciones { get; set; } //coleccion de publicaciones del candidato
        // una coleccion de cursos del candidato
        public ICollection<Curso> Cursos { get; set; } //coleccion de cursos del candidato


        //Icollection muchos a muchos
        public ICollection<CandidatoOfertaLaboral> CandidadtosOfertas { get; set; }
        public ICollection<CandidatoGrupo> CandidatosGrupos { get; set; }
        public ICollection<CandidatoHabilidad> CandidatosHabilidades { get; set; } // Relación con habilidades
        public ICollection<CandidatoCandidatoConexiones> CandidatosConexiones { get; set; } 
        public ICollection<CandidatoEmpresaConexiones> CandidatosEmpresasConexiones { get; set; } // Relación con empresas
        //>> una coleccion de candidatos seguidores del candidato
        public ICollection< CandidatoSeguidorCandidato> CandidatosSeguidores { get; set; } //>> una coleccion de candidatos seguidores del candidato
        //>> una coleccion de empresas seguidores del candidato
        public ICollection<CandidatoSeguidorEmpresa> CandidatosSeguidoresEmpresas { get; set; } //>> una coleccion de empresas seguidores del candidato
        
        public ICollection<EmpresaSeguidorCandidato> EmpresasSeguidoresCandidatos { get; set; } //>> una coleccion de usuarios seguidores del candidato   

        // Constructor por defecto
        public Candidato()
        {
        }

       // Constructor que recibe todos los parámetros
        public Candidato(int idUsuario, Usuario usuario, string tituloProfesional, string curriculumVitae, int seguidores, string fotoPerfil,
            ICollection<ExperienciaLaboral> experienciasLaborales, ICollection<Publicacion> publicaciones, ICollection<Curso> cursos,
            ICollection<CandidatoOfertaLaboral> candidadtosOfertas, ICollection<CandidatoGrupo> candidadtosGrupos,
            ICollection<CandidatoHabilidad> candidatosHabilidades, ICollection<CandidatoCandidatoConexiones> candidatosConexiones,
            ICollection<CandidatoEmpresaConexiones> candidatosEmpresasConexiones, ICollection<CandidatoSeguidorCandidato> candidatosSeguidores,
            ICollection<CandidatoSeguidorEmpresa> candidatosSeguidoresEmpresas, ICollection<EmpresaSeguidorCandidato> empresasSeguidoresCandidatos)
        {
            
            IdUsuario = idUsuario;
            Usuario = usuario;
            TituloProfesional = tituloProfesional;
            CurriculumVitae = curriculumVitae;
            Seguidores = seguidores;
            FotoPerfil = fotoPerfil;
            ExperienciasLaborales = experienciasLaborales;
            Publicaciones = publicaciones;
            Cursos = cursos;
            CandidadtosOfertas = candidadtosOfertas;
            CandidatosGrupos = candidadtosGrupos;
            CandidatosHabilidades = candidatosHabilidades;
            CandidatosConexiones = candidatosConexiones;
            CandidatosEmpresasConexiones = candidatosEmpresasConexiones;
            CandidatosSeguidores = candidatosSeguidores;
            CandidatosSeguidoresEmpresas = candidatosSeguidoresEmpresas;
            EmpresasSeguidoresCandidatos = empresasSeguidoresCandidatos;
        }









    }
}
