
using System;
using System.Collections.Generic;

namespace LikendlnApi.Models
{
    public class ParticipanteChat
    {
        // Propiedades
        public int ID { get; set; } // Identificador único del participante en el chat
        public DateTime FechaUnion { get; set; } // Fecha en que el participante se unió al chat

        public int IdCandidato { get; set; } // Identificador del candidato que es participante del chat

        public Candidato ParticipanteCandidato { get; set; }
        public int IdEmpresa { get; set; } // Identificador de la empresa que es participante del chat
        public Empresa ParticipanteEmpresa { get; set; }

        //uno a muchos
        public ICollection<ChatParticipante> Participantes { get; set; } // Colección de participantes en el chat


        //constructor por defecto
        public ParticipanteChat()
        {
        }

        // Constructor que recibe todos los parámetros
        public ParticipanteChat(int id, DateTime fechaUnion, int idCandidato, Candidato participanteCandidato,
            int idEmpresa, Empresa participanteEmpresa, ICollection<ChatParticipante> participantes)
        {
            ID = id;
            FechaUnion = fechaUnion;
            IdCandidato = idCandidato;
            ParticipanteCandidato = participanteCandidato;
            IdEmpresa = idEmpresa;
            ParticipanteEmpresa = participanteEmpresa;
            Participantes = participantes;


        }
    }
}