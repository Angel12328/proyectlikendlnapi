using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class MensajeEmpresarial : MensajeBase
    {
        public int ID { get; set; } // Identificador único del mensaje empresarial
        public int IDCandidatoDestinatario { get; set; } // Identificador del candidato que envía el mensaje
        public Candidato DestinatarioCandidato { get; set; }
        public int IDRemitenteCandidato { get; set; } // Identificador del candidato que envía el mensaje
        public Candidato RemitenteCandidato { get; set; } // Candidato que envía el mensaje
        public int IDRemitenteEmpresa { get; set; } // Identificador de la empresa que envía el mensaje (si aplica)
        public Empresa RemitenteEmpresa { get; set; } // Empresa que envía el mensaje (si aplica)
        public int IDDestinatarioEmpresa { get; set; } // Identificador de la empresa que recibe el mensaje (si aplica)
        public Empresa DestinatarioEmpresa { get; set; }
        public int IDOfertaLbrl{ get; set; } // Identificador de la empresa que envía el mensaje (si aplica)
        public OfertaLaboral OfertaLaboralRelacinada { get; set; }

        public bool Leido { get; set; }


        // Constructor por defecto
        public MensajeEmpresarial()
        {
        }
        // Constructor que recibe todos los parámetros
        public MensajeEmpresarial(int id, DateTime fechaEnvio, int idCandidato, Candidato remitenteCandidato, int idEmpresa, Empresa remitenteEmpresa, string contenido, bool leido, int idCandidatoDestinatario, Candidato destinatarioCandidato, int idRemitenteCandidato, Candidato remitenteCandidato2, int idRemitenteEmpresa, Empresa remitenteEmpresa2, int idDestinatarioEmpresa, Empresa destinatarioEmpresa, int idOfertaLaboral, OfertaLaboral ofertaLaboralRelacinada)
            : base(id, fechaEnvio, idCandidato, remitenteCandidato, idEmpresa, remitenteEmpresa, contenido, leido)
        {
            ID = id;
            IDCandidatoDestinatario = idCandidatoDestinatario;
            DestinatarioCandidato = destinatarioCandidato;
            IDRemitenteCandidato = idRemitenteCandidato;
            RemitenteCandidato = remitenteCandidato2;
            IDRemitenteEmpresa = idRemitenteEmpresa;
            RemitenteEmpresa = remitenteEmpresa2;
            IDDestinatarioEmpresa = idDestinatarioEmpresa;
            DestinatarioEmpresa = destinatarioEmpresa;
            IDOfertaLbrl = idOfertaLaboral;
            OfertaLaboralRelacinada = ofertaLaboralRelacinada;
        }









    }
}
