using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public abstract class MensajeBase
    {
        private int  _id;
        
        private DateTime _fechaEnvio;
        private Candidato _remitenteCandidato;
        private Empresa _remitenteEmpresa;


        


        public string Contenido {  get; set; }
        public bool Leido {  get; set; }

        public int Id { get { return _id; } set { _id = value; } }
        public DateTime FechaEnvio { get { return _fechaEnvio; } set { _fechaEnvio = value; } }
        public Candidato RemitenteCandidato { get { return _remitenteCandidato; } set { _remitenteCandidato = value; } }
        public Empresa RemitenteEmpresa { get { return _remitenteEmpresa; } set { _remitenteEmpresa = value; } }

        // Constructor por defecto
        public MensajeBase()
        {
        }

        // Constructor que recibe todos los parámetros
        public MensajeBase(int id, DateTime fechaEnvio, Candidato remitenteCandidato, Empresa remitenteEmpresa, string contenido, bool leido)
        {
            Id = id;
            FechaEnvio = fechaEnvio;
            RemitenteCandidato = remitenteCandidato;
            RemitenteEmpresa = remitenteEmpresa;
            Contenido = contenido;
            Leido = leido;
        }




    }
}
