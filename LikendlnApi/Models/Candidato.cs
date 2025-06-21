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
        //atributos
        private int _idCandidato;//id de candidiato
        private Usuario _usuario;
        private string _TituloProfesional;//tituo profesional del candidato
        private string _curriculumVitae;//curriculum vitae del candidato
        private List<Habilidad> ListHabilidades = new List<Habilidad>();//lista de habilidades del candidato
        private List<ExperienciaLaboral> ListexperienciasLaborales = new List<ExperienciaLaboral>();//lista de experiencias laborales del candidato
        private List<OfertaLaboral> ListOfertasPostuladas = new List<OfertaLaboral>();//lista de ofertas laborales a las que el candidato se ha postulado
        private List<Usuario> ListConexiones = new List<Usuario>();//lista de usuarios que el candidato sigue 
        private List<Grupo> ListGrupos = new List<Grupo>();//lista de grupos a los que el candidato pertenece
        private List<Publicacion> ListPublicaciones = new List<Publicacion>();//lista de publicaciones del candidato



        //Constructor por defecto
        public Candidato()
        {
        }

        //Constructor que recibe todos los parametros
        public Candidato(string nombre, string apellido, string coreoElectronico, string telefono, int idCandidato, Usuario usuario, string tituloProfesional, string curriculumVitae, List<Habilidad> listHabilidades, List<ExperienciaLaboral> listexperienciasLaborales, List<OfertaLaboral> listOfertasPostuladas, List<Usuario> listConexiones, List<Grupo> listGrupos, List<Publicacion> listPublicaciones) 
            : base(nombre, apellido, coreoElectronico, telefono)
        {
            IdCandidato = idCandidato;
            Usuario = usuario;
            TituloProfesional = tituloProfesional;
            CurriculumVitae = curriculumVitae;
            ListHabilidades1 = listHabilidades;
            ListexperienciasLaborales1 = listexperienciasLaborales;
            ListOfertasPostuladas1 = listOfertasPostuladas;
            ListConexiones1 = listConexiones;
            ListGrupos1 = listGrupos;
            ListPublicaciones1 = listPublicaciones;
        }

        //setters y getters
        public int IdCandidato { get { return _idCandidato; } set { _idCandidato = value; } }
        public string TituloProfesional { get { return _TituloProfesional; } set { _TituloProfesional = value; } }
        public string CurriculumVitae { get { return _curriculumVitae; } set { _curriculumVitae = value; } }
        internal Usuario Usuario { get { return _usuario; } set { _usuario = value; } }
        internal List<Habilidad> ListHabilidades1 { get { return ListHabilidades; } set { ListHabilidades = value; } }
        internal List<ExperienciaLaboral> ListexperienciasLaborales1 { get { return ListexperienciasLaborales; } set { ListexperienciasLaborales = value; } }
        internal List<OfertaLaboral> ListOfertasPostuladas1 { get { return ListOfertasPostuladas; } set { ListOfertasPostuladas = value; } }
        internal List<Usuario> ListConexiones1 { get { return ListConexiones; } set { ListConexiones = value; } }
        internal List<Grupo> ListGrupos1 { get { return ListGrupos; } set { ListGrupos = value; } }
        internal List<Publicacion> ListPublicaciones1 { get { return ListPublicaciones; } set { ListPublicaciones = value; } }

        //Metodo ToString
        public override string ToString()
        {
            return base.ToString() + $"IdCandidato: {IdCandidato}, TituloProfesional: {TituloProfesional}, CurriculumVitae: {CurriculumVitae}";


            }

        }
}
