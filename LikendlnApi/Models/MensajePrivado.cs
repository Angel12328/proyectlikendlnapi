using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class MensajePrivado : MensajeBase
    {
        public int ID { get; set; } // Identificador único del mensaje privado
        public int IDCandidato { get; set; } // Identificador del candidato que envía el mensaje
        public Candidato DestinatarioCandidato { get; set; }    

    // Identificador del candidato que recibe el mensaje
        public int IDRemitenteCandidato { get; set; } // Identificador del candidato que envía el mensaje
        public Candidato RemitenteCandidato { get; set; } // Candidato que envía el mensaje
        public int IDEmpresa { get; set; } // Identificador de la empresa que envía el mensaje (si aplica)
        public Empresa RemitenteEmpresa { get; set; } // Empresa que envía el mensaje (si aplica)
        public int IDChat { get; set; } // Identificador del chat al que pertenece el mensaje (si aplica)
        public Chat Chat { get; set; } // Chat al que pertenece el mensaje (si aplica)
        public bool Leido { get; set; }


        // Constructor por defecto
        public MensajePrivado()
        {
        }
        // Constructor que recibe todos los parámetros
        public MensajePrivado(int id, DateTime fechaEnvio, int idCandidato, Candidato remitenteCandidato, int idEmpresa, Empresa remitenteEmpresa, string contenido, bool leido, int idCandidatoDestinatario, Candidato destinatarioCandidato, int idRemitenteCandidato, Candidato remitenteCandidato2, int idChat, Chat chat)
            : base(id, fechaEnvio, idCandidato, remitenteCandidato, idEmpresa, remitenteEmpresa, contenido, leido)
        {
            ID = id;
            IDCandidato = idCandidato;
            DestinatarioCandidato = destinatarioCandidato;
            IDRemitenteCandidato = idRemitenteCandidato;
            RemitenteCandidato = remitenteCandidato2;
            IDEmpresa = idEmpresa;
            RemitenteEmpresa = remitenteEmpresa;
            IDChat = idChat;
            Chat = chat;
        }


    }
}
