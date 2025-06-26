using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public abstract class MensajeBase
    {
        public int  Id { get; set; } // Identificador único del mensaje

        public DateTime FechaEnvio { get; set; } // Fecha y hora en que se envió el mensaje
        public int IDCandidato { get; set; } // Identificador del candidato que envía el mensaje
        public Candidato RemitenteCandidato { get; set; } // Candidato que envía el mensaje
        public int IDEmpresa { get; set; } // Identificador de la empresa que envía el mensaje (si aplica)
        public Empresa RemitenteEmpresa { get; set; } // Empresa que envía el mensaje (si aplica)
        public int IDChat { get; set; } // Identificador del chat al que pertenece el mensaje (si aplica)
        public Chat Chat { get; set; } // Chat al que pertenece el mensaje (si aplica)

        public string Contenido {  get; set; }
        public bool Leido {  get; set; }

       // Constructor por defecto
        public MensajeBase()
        {
        }

       // Constructor que recibe todos los parámetros
        public MensajeBase(int id, DateTime fechaEnvio, int idCandidato, Candidato remitenteCandidato, int idEmpresa, Empresa remitenteEmpresa, string contenido, bool leido)
        {
            Id = id;
            FechaEnvio = fechaEnvio;
            IDCandidato = idCandidato;
            RemitenteCandidato = remitenteCandidato;
            IDEmpresa = idEmpresa;
            RemitenteEmpresa = remitenteEmpresa;
            Contenido = contenido;
            Leido = leido;
        }


    }
}
