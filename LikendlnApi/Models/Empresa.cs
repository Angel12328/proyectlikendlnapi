using LikendlnApi.Models.Data;
using LikendlnApi.Models.Relaciones;
using Microsoft.Ajax.Utilities;
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
        public int IdUsuario { get; set; } // Identificador del usuario que creó la empresa
        public Usuario Usuario { get; set; }
        
        public string NombreEmpresa { get; set; } 
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Sector { get; set; }
        public string SitioWeb { get; set; } // Sitio web de la empresa
        public string Tipo { get; set; }
        public DateTime FechaCreacion { get; set; } // Fecha de creación de la empresa
        public int Seguidores { get; set; }


        // Icollection
        public ICollection<CandidatoEmpresaConexiones> CandidatosEmpresasConexiones { get; set; } // Relación con candidatos
        public ICollection<Publicacion> Publicaciones { get; set; } //coleccion de publicaciones de la empresa
        //>> una coleccion de candidatos seguidores de la empresa
        //>> una coleccion de empresas seguidores de la empresa


        //Ofertas que la empresa ofrece
        public List<OfertaLaboral> OfertasLaborales { get; set; } = new List<OfertaLaboral>();

          // Número de seguidores de la empresa
        


        //xd
        // Constructor que recibe el ID y el usuario
        // Constructor por defecto
        public Empresa()
        {
            
        }


        // Constructor que recibe todos los parámetros





       




    }
}
