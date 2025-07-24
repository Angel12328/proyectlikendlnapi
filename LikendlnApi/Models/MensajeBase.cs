using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public abstract class MensajeBase
    {
        public int  Id { get; set; } // Identificador único del mensaje

        public DateTime FechaEnvio { get; set; } // Fecha y hora en que se envió el mensaje
        public int IdRemitenteCandidato { get; set; } // Identificador del candidato que envía el mensaje
        public virtual Candidato RemitenteCandidato { get; set; } // Candidato que envía el mensaje
        public int IdRemitenteEmpresa { get; set; } // Identificador de la empresa que envía el mensaje (si aplica)
        public virtual Empresa RemitenteEmpresa { get; set; } // Empresa que envía el mensaje (si aplica)
        public int IdChat { get; set; } // Identificador del chat al que pertenece el mensaje (si aplica)
        public virtual Chat Chat { get; set; } // Chat al que pertenece el mensaje (si aplica)

        public string Contenido {  get; set; }
        public bool Leido {  get; set; }

        // Constructor por defecto
        public MensajeBase()
        {
        }

        protected MensajeBase(int id, DateTime fechaEnvio, int iDCandidato, Candidato remitenteCandidato, int iDEmpresa, Empresa remitenteEmpresa, int iDChat, Chat chat, string contenido, bool leido)
        {
            Id = id;
            FechaEnvio = fechaEnvio;
            IdRemitenteCandidato = iDCandidato;
            RemitenteCandidato = remitenteCandidato;
            IdRemitenteEmpresa = iDEmpresa;
            RemitenteEmpresa = remitenteEmpresa;
            IdChat = iDChat;
            Chat = chat;
            Contenido = contenido;
            Leido = leido;
        }

        // Constructor que recibe todos los parámetros










    }
}
