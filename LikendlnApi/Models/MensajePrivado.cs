using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class MensajePrivado : MensajeBase
    {
        public Candidato DestinatarioCandidato { get; set; }    

        public MensajePrivado()
        {
        }
        public MensajePrivado(int id, DateTime fechaEnvio, Candidato remitenteCandidato, Empresa remitenteEmpresa, string contenido, bool leido, Candidato destinatarioCandidato)
            : base(id, fechaEnvio, remitenteCandidato, remitenteEmpresa, contenido, leido)
        {
            DestinatarioCandidato = destinatarioCandidato;
        }




    }
}
