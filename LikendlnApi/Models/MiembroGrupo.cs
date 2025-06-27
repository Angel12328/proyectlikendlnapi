using System;

namespace LikendlnApi.Models
{
    public class MiembroGrupo
    {
        public int ID { get; set; } // Identificador único del miembro del grupo
        public DateTime FechaUnion { get; set; } // Fecha en que el miembro se unió al grupo

        public int IDMiembroCandidato { get; set; } // Identificador del candidato que es miembro del grupo

        public Candidato MiembroCandidato { get; set; }
        public int IDMiembroEmpresa { get; set; } // Identificador de la empresa que es miembro del grupo
        public Empresa MiembroEmpresa { get; set; }
        public int IDGrupo { get; set; } // Identificador del grupo al que pertenece el miembro
        public Grupo Grupo { get; set; }
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
            IDMiembroCandidato = idMiembroCandidato;
            MiembroCandidato = miembroCandidato;
            IDMiembroEmpresa = idMiembroEmpresa;
            MiembroEmpresa = miembroEmpresa;
            IDGrupo = idGrupo;
            Grupo = grupo;
            RolGrupo = rolGrupo;
        }
    }
}