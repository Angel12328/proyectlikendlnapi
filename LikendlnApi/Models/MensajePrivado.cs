using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace LikendlnApi.Models
{
    public class MensajePrivado : MensajeBase
    {
      
        public int IDDestinatarioCandidato { get; set; } // Identificador del candidato que envía el mensaje
        public virtual Candidato DestinatarioCandidato { get; set; }



        // Constructor por defecto
        public MensajePrivado()
        {
        }

        // Constructor que recibe todos los parámetros

        public MensajePrivado(
            int id,
            DateTime fechaEnvio,
            int idCandidato,
            Candidato remitenteCandidato,
            int idEmpresa,
            Empresa remitenteEmpresa,
            int idChat,
            Chat chat,
            string contenido,
            bool leido,
            int idDestinatarioCandidato,
            Candidato destinatarioCandidato)
            : base(id, fechaEnvio, idCandidato, remitenteCandidato, idEmpresa, remitenteEmpresa, idChat, chat, contenido, leido)
        {
            
            IDDestinatarioCandidato = idDestinatarioCandidato;
            DestinatarioCandidato = destinatarioCandidato;
        }













    }
}
