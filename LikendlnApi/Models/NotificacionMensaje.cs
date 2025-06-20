using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class NotificacionMensaje
    {
        private int _id;
        private DateTime _fechaNotificacion;



        public Candidato Candidato { get; set; }
        public Empresa Empresa { get; set; }
        public MensajeBase Mensaje { get; set; }
        public bool Leido { get; set; }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime FechaNotificacion
        {
            get { return _fechaNotificacion; }
            set { _fechaNotificacion = value; }
        }

        // Constructor por defecto
        public NotificacionMensaje() { }

        // Constructor que recibe todos los parámetros
        public NotificacionMensaje(int id, DateTime fechaNotificacion, Candidato candidato, Empresa empresa, MensajeBase mensaje, bool leido)
        {
            Id = id;
            FechaNotificacion = fechaNotificacion;
            Candidato = candidato;
            Empresa = empresa;
            Mensaje = mensaje;
            Leido = leido;
        }


    }
}
