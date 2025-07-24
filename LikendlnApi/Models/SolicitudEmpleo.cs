using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class SolicitudEmpleo
    {
        //atributos
        public int ID { get; set; }
        public int IdCandidato { get; set; } // Identificador del candidato que realiza la solicitud
        public virtual Candidato Candidato { get; set; } // Candidato que realiza la solicitud
        public int IdEmpresa { get; set; } // Identificador de la empresa a la que se solicita el empleo
        public virtual Empresa Empresa { get; set; }
        public string Titulo { get; set; } // Título de la solicitud de empleo
        public string Descripcion { get; set; } // Descripción de la solicitud de empleo
        public int IdOfertaLaboral { get; set; } // Identificador de la oferta laboral a la que se está solicitando empleo
        public virtual OfertaLaboral OfertaLaboral { get; set; } // Oferta laboral a la que se está solicitando empleo
        public DateTime FechaSolicitud { get; set; } // Fecha en que se realiza la solicitud de empleo
        public string Estado { get; set; } // Ejemplo: "Pendiente", "Aceptada", "Rechazada"


        // Constructor por defecto
        public SolicitudEmpleo()
        {
        }

        public SolicitudEmpleo(int iD, int idCandidato, Candidato candidato, int idEmpresa, Empresa empresa, string titulo,
            string descripcion, int idOfertaLaboral, OfertaLaboral ofertaLaboral, DateTime fechaSolicitud, string estado)
        {
            ID = iD;
            IdCandidato = idCandidato;
            Candidato = candidato;
            IdEmpresa = idEmpresa;
            Empresa = empresa;
            Titulo = titulo;
            Descripcion = descripcion;
            IdOfertaLaboral = idOfertaLaboral;
            OfertaLaboral = ofertaLaboral;
            FechaSolicitud = fechaSolicitud;
            Estado = estado;
        }
    }
}
