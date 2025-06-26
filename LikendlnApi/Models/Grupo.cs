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
        // Propiedades
        public int ID { get; set; }
        public int IDCreador { get; set; } // Identificador del creador del grupo
        public Candidato CreadorCandidato { get; set; }
        public int IdEmpresa { get; set; } // Identificador de la empresa que crea el grupo
        public Empresa CreadorEmpresa { get; set; }

        public string FotoPerfil { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsPrivado { get; set; }


        //uno  a muchos
        public ICollection<MiembroGrupo> Miembros { get; set; } // Colección de miembros del grupo
        public ICollection<Publicacion> Publicaciones { get; set; } // Colección de publicaciones del grupo

        public ICollection<CandidatoGrupo> CandidadtosGrupos { get; set; }


        // Constructor por defecto
        public Grupo()
        {
          
        }

        // Constructor que recibe todos los parámetros

        public Grupo(int iD, int iDCreador, Candidato creadorCandidato, int idEmpresa, Empresa creadorEmpresa, string fotoPerfil, string nombre, string descripcion, bool esPrivado,
            ICollection<MiembroGrupo> miembros, ICollection<Publicacion> publicaciones, ICollection<CandidatoGrupo> candidadtosGrupos)
        {
            ID = iD;
            IDCreador = iDCreador;
            CreadorCandidato = creadorCandidato;
            IdEmpresa = idEmpresa;
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
