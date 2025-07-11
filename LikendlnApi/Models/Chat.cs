
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

        //UNO A MUCHOS
        public virtual ICollection<MensajeBase> Mensajes { get; set; }

        //muchos a muchos
        public virtual ICollection<ChatParticipante> Participantes { get; set; } // Colección de participantes en el chat


       


        // Constructor por defecto
        public Chat()
        {
          
        }

       // Constructor que recibe todos los parámetros
        public Chat(int id, DateTime fechaCreacion, DateTime ultimaActividad, string titulo, ICollection<MensajeBase> mensajes, ICollection<ChatParticipante> participantes)
        {
            ID = id;
            FechaCreacion = fechaCreacion;
            UltimaActividad = ultimaActividad;
            Titulo = titulo;
            Mensajes = mensajes;
            Participantes = participantes;
        }


    }
}
