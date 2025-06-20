using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class Usuario
    {
        //Atributos
        private int _idUsuario;
        private string _contrasena;
        
        private List<Empresa> _Empresas = new List<Empresa>(); //Lista d empresas que puede manejar un usuario

        //Constructor por defecto
        public Usuario()
        {
        }

        //Constructor que recibe todos los parametros
        public Usuario(int idUsuario, string contrasena, List<Empresa> empresas, string correo)
        {
            IdUsuario = idUsuario;
            Contrasena = contrasena;
            Empresas = empresas;
            
        }

        //setters y getters

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        public string Contrasena
        {
            get { return _contrasena; }
            set
            {
                _contrasena = value;
            }


        }


        internal List<Empresa> Empresas { get => _Empresas; set => _Empresas = value; }

        //metodo toString
        public override string ToString()
        {
            return $"Id: {IdUsuario}, Empresas: {Empresas}";

        }
    }
}
