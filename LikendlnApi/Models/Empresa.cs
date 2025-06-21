using LikendlnApi.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class Empresa
    {
        //Propiedades
        public int ID { get; set; }
        public Usuario Usuario { get; set; } 
        public string NombreEmpresa { get; set; } 
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Sector { get; set; }

        //Ofertas que la empresa ofrece
        public List<OfertaLaboral> OfertasLaborales { get; set; } = new List<OfertaLaboral>();

        // Publicaciones de la empresa
        public List<Publicacion> Publicaciones { get; set; }  = new List<Publicacion>();

        //xd
        // Constructor que recibe el ID y el usuario
        // Constructor por defecto
        public Empresa()
        {
        }


        // Constructor que recibe todos los parámetros
        public Empresa(int id, Usuario usuario, string nombreEmpresa, string descripcion, string direccion, string telefono,
            string correoElectronico, string sector)
        {
            ID = id;
            Usuario = usuario;
            NombreEmpresa = nombreEmpresa;
            Descripcion = descripcion;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            Sector = sector;
        }




       




    }
}
