using System;

namespace LikendlnApi.Models.Data
{
    public class ParticipanteChat
    {
        private int _id;
        private DateTime _fechaUnion;
        


        public Candidato ParticipanteCandidato { get; set; }
        public Empresa ParticipanteEmpresa { get; set; }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime FechaUnion
        {
            get { return _fechaUnion; }
            set { _fechaUnion = value; }
        }



        // Constructor por defecto
        public ParticipanteChat() { }

        // Constructor que recibe todos los parámetros
        public ParticipanteChat(int id, DateTime fechaUnion, Candidato participanteCandidato, Empresa participanteEmpresa)
        {
            Id = id;
            FechaUnion = fechaUnion;
            ParticipanteCandidato = participanteCandidato;
            ParticipanteEmpresa = participanteEmpresa;
        }






    }
}