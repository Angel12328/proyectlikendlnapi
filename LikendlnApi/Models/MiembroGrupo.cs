using System;

namespace LikendlnApi.Models
{
    public class MiembroGrupo
    {
        //Cambio en la rama main
        public int ID { get; set; } // Identificador único del miembro del grupo
        public DateTime FechaUnion { get; set; } // Fecha en que el miembro se unió al grupo

        public int? IdMiembroCandidato { get; set; } // Identificador del candidato que es miembro del grupo

        public virtual Candidato MiembroCandidato { get; set; }
        public int? IdMiembroEmpresa { get; set; } // Identificador de la empresa que es miembro del grupo
        public virtual Empresa MiembroEmpresa { get; set; }
        public int IdGrupo { get; set; } // Identificador del grupo al que pertenece el miembro
        public virtual Grupo Grupo { get; set; }
        public string RolGrupo { get; set; }

       // Constructor por defecto
        public MiembroGrupo()
        {
        }
        // Constructor que recibe todos los parámetros
        public MiembroGrupo(int id, DateTime fechaUnion, int idMiembroCandidato, Candidato miembroCandidato,
            int idMiembroEmpresa, Empresa miembroEmpresa, int idGrupo, Grupo grupo, string rolGrupo)
        {
            ID = id;
            FechaUnion = fechaUnion;
            IdMiembroCandidato = idMiembroCandidato;
            MiembroCandidato = miembroCandidato;
            IdMiembroEmpresa = idMiembroEmpresa;
            MiembroEmpresa = miembroEmpresa;
            IdGrupo = idGrupo;
            Grupo = grupo;
            RolGrupo = rolGrupo;
        }
    }
}