using LikendlnApi.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class Chat
    {
        private int _id;
        
        private DateTime _fechaCreacion;
        private DateTime _ultimaActividad;


        public string Titulo { get; set; }
        public List<ParticipanteChat> Participantes { get; set; }

        public List<MensajeBase> Mensajes { get; set; }

        public int Id { get { return _id; } set { _id = value; } }
        public DateTime FechaCreacion { get { return _fechaCreacion; } set { _fechaCreacion = value; } }
        public DateTime UltimaActividad { get { return _ultimaActividad; } set { _ultimaActividad = value; } }

        // Constructor por defecto
        public Chat()
        {
        }

        // Constructor que recibe todos los parámetros
        public Chat(int id, DateTime fechaCreacion, DateTime ultimaActividad, string titulo, List<ParticipanteChat> participantes, List<MensajeBase> mensajes)
        {
            Id = id;
            FechaCreacion = fechaCreacion;
            UltimaActividad = ultimaActividad;
            Titulo = titulo;
            Participantes = participantes ?? new List<ParticipanteChat>();
            Mensajes = mensajes ?? new List<MensajeBase>();
        }

        


    }
}
