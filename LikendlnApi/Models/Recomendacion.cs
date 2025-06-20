using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class Recomendacion
    {
        //atributos
        private int _idRecomendacion;
        private Usuario _recomendadorUsuario; // Usuario que hace la recomendación
        private Empresa _recomendadorEmpresa; // Empresa qe hace la recomendación
        private string _mensaje;
        private DateTime _fecha;

        //constructor por defecto
        public Recomendacion()
        {
        }

        //constructor que recibe todos los parametros
        public Recomendacion(int idRecomendacion, Usuario recomendadorUsuario, Empresa recomendadorEmpresa, string mensaje, DateTime fecha)
        {
            IdRecomendacion = idRecomendacion;
            RecomendadorUsuario = recomendadorUsuario;
            RecomendadorEmpresa = recomendadorEmpresa;
            Mensaje = mensaje;
            Fecha = fecha;
        }

        //sett y gett
        public int IdRecomendacion { get { return _idRecomendacion; } set { _idRecomendacion = value; } }
        public string Mensaje { get { return _mensaje; } set { _mensaje = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
        internal Usuario RecomendadorUsuario { get { return _recomendadorUsuario; } set { _recomendadorUsuario = value; } }
        internal Empresa RecomendadorEmpresa { get { return _recomendadorEmpresa; } set { _recomendadorEmpresa = value; } }

        //toString
        public override string ToString()
        {
            return base.ToString();
        }
    }


}
