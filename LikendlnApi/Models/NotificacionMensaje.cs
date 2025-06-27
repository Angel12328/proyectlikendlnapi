using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class NotificacionMensaje
    {
        public int ID { get; set; } // Identificador único de la notificación de mensaje
        public DateTime FechaNotificacion { get; set; } // Fecha y hora de la notificación

        public int IDCandidato { get; set; } // Identificador del candidato al que se le envía la notificación

        public Candidato Candidato { get; set; }
        public int IDEmpresa { get; set; } // Identificador de la empresa que envía la notificación (si aplica)
        public Empresa Empresa { get; set; }
        public int IdMensajeBase { get; set; } // Identificador del mensaje asociado a la notificación
        public MensajeBase Mensaje { get; set; }
        public bool Leido { get; set; }


       // Constructor por defecto
        public NotificacionMensaje()
        {
        }

        // Constructor que recibe todos los parámetros
        public NotificacionMensaje(int id, DateTime fechaNotificacion, int iDCandidato, Candidato candidato, int iDEmpresa, Empresa empresa, int idMensajeBase, MensajeBase mensaje, bool leido)
        {
            ID = id;
            FechaNotificacion = fechaNotificacion;
            IDCandidato = iDCandidato;
            Candidato = candidato;
            IDEmpresa = iDEmpresa;
            Empresa = empresa;
            IdMensajeBase = idMensajeBase;
            Mensaje = mensaje;
            Leido = leido;
        }

    }
}
