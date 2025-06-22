using LikendlnApi.Models.Relaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class Grupo
    {
        private int _id;
        private Candidato _creadorCandidato;
        private Empresa _creadorEmpresa;

        private List<MiembroGrupo> _miembros;
        private List<Publicacion> _publicaciones;

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsPrivado { get; set; }

        // ICollection
        public ICollection<CandidatoGrupo> CandidadtosGrupos { get; set; }


        // Propiedades
        public int Id { get { return _id; } set { _id = value; } }
        public Candidato CreadorCandidato { get { return _creadorCandidato; } set { _creadorCandidato = value; } }
        public Empresa CreadorEmpresa { get { return _creadorEmpresa; } set { _creadorEmpresa = value; } }
        public List<MiembroGrupo> Miembros { get { return _miembros; } set { _miembros = value; } }
        public List<Publicacion> Publicaciones { get { return _publicaciones; } set { _publicaciones = value; } }

       



    }
}
