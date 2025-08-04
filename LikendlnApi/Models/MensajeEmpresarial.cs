using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace LikendlnApi.Models
{
    public class MensajeEmpresarial : MensajeBase
    {
        
        public int? IDDestinatarioCandidato { get; set; } // Identificador del candidato que envía el mensaje
        public Candidato DestinatarioCandidato { get; set; }

        public int? IDDestinatarioEmpresa { get; set; } // Identificador de la empresa que recibe el mensaje (si aplica)
        public Empresa DestinatarioEmpresa { get; set; }
        public int IDOfertaLaboralRelacinada { get; set; } // Identificador de la empresa que envía el mensaje (si aplica)
        public OfertaLaboral OfertaLaboralRelacinada { get; set; }

        


        // Constructor por defecto
        public MensajeEmpresarial()
        {
        }

        // Constructor que recibe todos los parámetros

        public MensajeEmpresarial(
            int id,
            DateTime fechaEnvio,
            int idCandidatoEmisor,
            Candidato emisorCandidato,
            int idEmpresaEmisor,
            Empresa emisorEmpresa,
            int idChat,
            Chat chat,
            string contenido,
            bool leido,
            int idCandidatoDestinatario,
            Candidato destinatarioCandidato,
            int idDestinatarioEmpresa,
            Empresa destinatarioEmpresa,
            int idOfertaLbrl,
            OfertaLaboral ofertaLaboralRelacinada)
            : base(id, fechaEnvio, idCandidatoEmisor, emisorCandidato, idEmpresaEmisor, emisorEmpresa, idChat, chat, contenido, leido)
        {

            IDDestinatarioCandidato = idCandidatoDestinatario;
            DestinatarioCandidato = destinatarioCandidato;
            IDDestinatarioEmpresa = idDestinatarioEmpresa;
            DestinatarioEmpresa = destinatarioEmpresa;
            IDOfertaLaboralRelacinada = idOfertaLbrl;
            OfertaLaboralRelacinada = ofertaLaboralRelacinada;
        }













    }
}
