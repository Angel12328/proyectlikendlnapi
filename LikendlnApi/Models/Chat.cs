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
        // Propiedades
        public int ID { get; set; } // Identificador único del chat

        public DateTime FechaCreacion { get; set; } // Fecha y hora en que se creó el chat
        public DateTime UltimaActividad { get; set; } // Fecha y hora de la última actividad en el chat


        public string Titulo { get; set; }


        public ICollection<ParticipanteChat> Participantes { get; set; } // Colección de participantes en el chat

        public ICollection<MensajeBase> Mensajes { get; set; }


        // Constructor por defecto
        public Chat()
        {
            Participantes = new List<ParticipanteChat>();
            Mensajes = new List<MensajeBase>();
        }

        // Constructor que recibe todos los parámetros
        public Chat(int iD, DateTime fechaCreacion, DateTime ultimaActividad, string titulo, ICollection<ParticipanteChat> participantes, ICollection<MensajeBase> mensajes)
        {
            ID = iD;
            FechaCreacion = fechaCreacion;
            UltimaActividad = ultimaActividad;
            Titulo = titulo;
            Participantes = participantes;
            Mensajes = mensajes;
        }



    }
}
