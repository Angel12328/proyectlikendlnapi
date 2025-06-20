using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class MensajeEmpresarial : MensajeBase
    {
        public Candidato DestinatarioCandidato { get; set; }
        public Empresa DestinatarioEmpresa { get; set; }
        public OfertaLaboral OfertaLaboralRelacinada { get; set; }

        public bool Leido { get; set; }

        // Constructor por defecto
        public MensajeEmpresarial()
        {
        }

        // Constructor que recibe todos los parámetros
        public MensajeEmpresarial(int id, DateTime fechaEnvio, Candidato remitenteCandidato, Empresa remitenteEmpresa, string contenido, bool leido, Candidato destinatarioCandidato, Empresa destinatarioEmpresa, OfertaLaboral ofertaLaboralRelacinada)
            : base(id, fechaEnvio, remitenteCandidato, remitenteEmpresa, contenido, leido)
        {
            DestinatarioCandidato = destinatarioCandidato;
            DestinatarioEmpresa = destinatarioEmpresa;
            OfertaLaboralRelacinada = ofertaLaboralRelacinada;
        }

        



    }
}
