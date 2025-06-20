using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class SolicitudEmpleo
    {
        //atributos
        private int _idSolicitudEmpleo;
        private Candidato _candidato;
        private Empresa _empresa;
        private string _titulo;
        private string _descripcion;
        private OfertaLaboral _ofertaLaboral;
        private DateTime _fechaSolicitud;
        private string _estado; // Ejemplo: "Pendiente", "Aceptada", "Rechazada"

        // Constructor por defecto
        public SolicitudEmpleo()
        {
        }

        // Constructor que recibe todos los parámetros
        public SolicitudEmpleo(int idSolicitudEmpleo, Candidato candidato, Empresa empresa, string titulo, string descripcion, OfertaLaboral ofertaLaboral, DateTime fechaSolicitud, string estado)
        {
            IdSolicitudEmpleo = idSolicitudEmpleo;
            Candidato = candidato;
            Empresa = empresa;
            Titulo = titulo;
            Descripcion = descripcion;
            OfertaLaboral = ofertaLaboral;
            FechaSolicitud = fechaSolicitud;
            Estado = estado;
        }

        // Setters y Getters
        public int IdSolicitudEmpleo { get { return _idSolicitudEmpleo; } set { _idSolicitudEmpleo = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public DateTime FechaSolicitud { get { return _fechaSolicitud; } set { _fechaSolicitud = value; } }
        public string Estado { get { return _estado; } set { _estado = value; } }
        internal Candidato Candidato { get { return _candidato; } set { _candidato = value; } }
        internal Empresa Empresa { get { return _empresa; } set { _empresa = value; } }
        internal OfertaLaboral OfertaLaboral { get { return _ofertaLaboral; } set { _ofertaLaboral = value; } }

      //toString
        public override string ToString()
        {
            return $"Id: {IdSolicitudEmpleo}, Candidato: {Candidato.Nombre}, Empresa: {Empresa.NombreEmpresa}, Titulo: {Titulo}, Descripcion: {Descripcion}, Fecha Solicitud: {FechaSolicitud.ToShortDateString()}, Estado: {Estado}";
        }


    }
}
