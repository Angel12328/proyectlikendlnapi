using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class OfertaLaboral
    {
        //atributos
        private int _idOfertaLaboral;
        private Empresa _empresa;
        private string _titulo;
        private string _descripcion;
        private string _ubicacion;
        private string _tipoContrato;
        private double _salarioMin;
        private double _salarioMax;
        private DateTime _fechaPublicacion;
        private DateTime _fechaExpiracion;

        private bool _disponible;


        private List<Candidato> postulantes = new List<Candidato>();//lista de candidatos postulantes a la oferta laboral
        private  List<Habilidad> HabilidadesRequeridas = new List<Habilidad>();//lista de habilidades requeridas para la oferta laboral

   


        //Constructor por defecto
        public OfertaLaboral()
        {
        }

        //Constructor que recibe todos los parametros
        public OfertaLaboral(int idOfertaLaboral, Empresa empresa, string titulo, string descripcion, string ubicacion,
            string tipoContrato, double salarioMin, double salarioMax, DateTime fechaPublicacion, DateTime fechaExpiracion, bool disponible)
        {
            IdOfertaLaboral = idOfertaLaboral;
            Empresa = empresa;
            Titulo = titulo;
            Descripcion = descripcion;
            Ubicacion = ubicacion;
            TipoContrato = tipoContrato;
            SalarioMin = salarioMin;
            SalarioMax = salarioMax;
            FechaPublicacion = fechaPublicacion;
            FechaExpiracion = fechaExpiracion;
            Disponible = disponible;
        }

        //setters y getters
        public int IdOfertaLaboral { get { return _idOfertaLaboral; } set { _idOfertaLaboral = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string Ubicacion { get { return _ubicacion; } set { _ubicacion = value; } }
        public string TipoContrato { get { return _tipoContrato; } set { _tipoContrato = value; } }
        public double SalarioMin { get { return _salarioMin; } set { _salarioMin = value; } }
        public double SalarioMax { get { return _salarioMax; } set { _salarioMax = value; } }
        public DateTime FechaPublicacion { get { return _fechaPublicacion; } set { _fechaPublicacion = value; } }
        public DateTime FechaExpiracion { get { return _fechaExpiracion; } set { _fechaExpiracion = value; } }
        public bool Disponible { get { return _disponible; } set { _disponible = value; } }
        internal Empresa Empresa { get { return _empresa; } set { _empresa = value; } }
        internal List<Candidato> Postulantes { get { return postulantes; } set { postulantes = value; } }
        internal List<Habilidad> HabilidadesRequeridas1 { get { return HabilidadesRequeridas; } set { HabilidadesRequeridas = value; } }

        //Metodo ToString

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
