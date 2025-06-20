using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class Empresa
    {
        //Atributos
        private int _idEmpresa;
        private Usuario _usuario;
        private string _nombreEmpresa;
        private string _descripcion;
        private string _direccion;
        private string _telefono;
        private string _correoElectronico;
        private string _sector;

        //Ofertas que la empresa ofrece
        List<OfertaLaboral> OfertasLaborales = new List<OfertaLaboral>();

        // Publicaciones de la empresa
        private List<Publicacion> Publicaciones  = new List<Publicacion>();

        //Constructor por defecto
        public Empresa()
        {
        }

        //Constructor que recibe todos los parametros
        public Empresa(int idEmpresa, Usuario usuario, string nombreEmpresa, string descripcion, string direccion, string telefono, string correoElectronico, string sector)
        {
            IdEmpresa = idEmpresa;
            Usuario = usuario;
            NombreEmpresa = nombreEmpresa;
            Descripcion = descripcion;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            Sector = sector;
        }

        //setters y getters
        public int IdEmpresa { get { return _idEmpresa; } set { _idEmpresa = value; } }
        public string NombreEmpresa { get { return _nombreEmpresa; } set { _nombreEmpresa = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string CorreoElectronico { get { return _correoElectronico; } set { _correoElectronico = value; } }
        public string Sector { get { return _sector; } set { _sector = value; } }
        internal Usuario Usuario { get { return _usuario; } set { _usuario = value; } }
        internal List<OfertaLaboral> OfertasLaborales1 { get { return OfertasLaborales; } set { OfertasLaborales = value; } }
        internal List<Publicacion> Publicaciones1 { get { return Publicaciones; } set { Publicaciones = value; } }

        //metodo toString
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
