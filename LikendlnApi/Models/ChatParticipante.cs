
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class ChatParticipante
    {
        public int Id { get; set; }
        public int ChatId { get; set; } // Identificador del chat al que pertenece el participante
        public Chat Chat { get; set; } // Referencia al chat al que pertenece el participante
        public int ParticipanteId { get; set; } // Identificador del participante (Candidato o Empresa)
        public ParticipanteChat ParticipanteChat { get; set; } // Referencia al participante del chat (Candidato o Empresa)

        // Constructor por defecto
        public ChatParticipante()
        {
        }
        // Constructor que recibe todos los parámetros
        public ChatParticipante(int id, int chatId, Chat chat, int participanteId, ParticipanteChat participanteChat)
        {
            Id = id;
            ChatId = chatId;
            Chat = chat;
            ParticipanteId = participanteId;
            ParticipanteChat = participanteChat;
        }

    }
}