using System;

namespace LikendlnApi.Models.Data
{
    public class MiembroGrupo
    {
        private int _id;
        private DateTime _fechaUnion;



        public Candidato MiembroCandidato { get; set; }
        public Empresa MiembroEmpresa { get; set; }
        public Grupo Grupo { get; set; }
        public string RolGrupo { get; set; }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime FechaUnion
        {
            get { return _fechaUnion; }
            set { _fechaUnion = value; }

        }

        
        public MiembroGrupo() { }

        public MiembroGrupo(Candidato miembroCandidato, Empresa miembroEmpresa, Grupo grupo, string rolGrupo, int id, DateTime fechaUnion)
        {
            MiembroCandidato = miembroCandidato;
            MiembroEmpresa = miembroEmpresa;
            Grupo = grupo;
            RolGrupo = rolGrupo;
            Id = id;
            FechaUnion = fechaUnion;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}