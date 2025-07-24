
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class Grupo
    {
        // Propiedades
        public int ID { get; set; }
        public int IdCreadorCandidato { get; set; } // Identificador del creador del grupo
        public virtual Candidato CreadorCandidato { get; set; }
        public int IdCreadorEmpresa { get; set; } // Identificador de la empresa que crea el grupo
        public virtual Empresa CreadorEmpresa { get; set; }

        public string FotoPerfil { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsPrivado { get; set; }


        //uno  a muchos
        public virtual ICollection<MiembroGrupo> Miembros { get; set; } // Colección de miembros del grupo
        public virtual ICollection<Publicacion> Publicaciones { get; set; } // Colección de publicaciones del grupo

        public virtual ICollection<CandidatoGrupo> CandidadtosGrupos { get; set; }


        // Constructor por defecto
        public Grupo()
        {
          
        }

        // Constructor que recibe todos los parámetros

        public Grupo(int iD, int iDCreador, Candidato creadorCandidato, int idEmpresa, Empresa creadorEmpresa, string fotoPerfil, string nombre, string descripcion, bool esPrivado,
            ICollection<MiembroGrupo> miembros, ICollection<Publicacion> publicaciones, ICollection<CandidatoGrupo> candidadtosGrupos)
        {
            ID = iD;
            IdCreadorCandidato = iDCreador;
            CreadorCandidato = creadorCandidato;
            IdCreadorEmpresa = idEmpresa;
            CreadorEmpresa = creadorEmpresa;
            FotoPerfil = fotoPerfil;
            Nombre = nombre;
            Descripcion = descripcion;
            EsPrivado = esPrivado;
            Miembros = miembros;
            Publicaciones = publicaciones;
            CandidadtosGrupos = candidadtosGrupos;
        }

   



    }
}
