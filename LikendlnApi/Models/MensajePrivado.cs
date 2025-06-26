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

      // Constructor por defecto
        public MensajePrivado()
        {
        }
        // Constructor que recibe todos los parámetros
        public MensajePrivado(int id, DateTime fechaEnvio, int idCandidato, Candidato remitenteCandidato, int idEmpresa, Empresa remitenteEmpresa, string contenido, bool leido, int idDestinatarioCandidato, Candidato destinatarioCandidato)
            : base(id, fechaEnvio, idCandidato, remitenteCandidato, idEmpresa, remitenteEmpresa, contenido, leido)
        {
            ID = id;
            IDCandidato = idCandidato;
            DestinatarioCandidato = destinatarioCandidato;
        }



    }
}
