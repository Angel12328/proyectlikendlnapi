
using LikendlnApi.Controllers;
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
        public virtual Usuario Usuario { get; set; }
        
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


        public string FotoPerfil { get; set; }


        // Icollection
        //uno a muchos
        public virtual ICollection<Publicacion> Publicaciones { get; set; }
        

        //muchos a muchos
        public virtual ICollection<CandidatoEmpresaConexiones> CandidatosEmpresasConexiones { get; set; } // Relación con candidatos\
        public virtual ICollection<CandidatoSeguidorEmpresa> CandidatosSeguidoresEmpresas { get; set; } //>> una coleccion de empresas seguidores del candidato

        //>> una coleccion de candidatos seguidores de la empresa
        public virtual ICollection<EmpresaSeguidorCandidato> EmpresasCandidatosSeguidores { get; set; } //>> una coleccion de candidatos seguidores de la empresa

        //>> una coleccion de empresas seguidores de la empresa
        public virtual ICollection<EmpresaSeguidorEmpresa> EmpresasSeguidoresEmpresa { get; set; } //>> una coleccion de empresas seguidores de la empresa


        //Ofertas que la empresa ofrece
        public virtual ICollection<OfertaLaboral> OfertasLaborales { get; set; }

        // Constructor por defecto
        public Empresa()
        {
        }

        public Empresa(int iD, int idUsuario, Usuario usuario, string nombreEmpresa, string descripcion, string direccion, string telefono, string correoElectronico, string sector, string sitioWeb, string tipo, DateTime fechaCreacion, int seguidores, string fotoPerfil, ICollection<Publicacion> publicaciones, ICollection<CandidatoEmpresaConexiones> candidatosEmpresasConexiones, ICollection<CandidatoSeguidorEmpresa> candidatosSeguidoresEmpresas, ICollection<EmpresaSeguidorCandidato> empresasCandidatosSeguidores, ICollection<EmpresaSeguidorEmpresa> empresasSeguidoresEmpresa, ICollection<OfertaLaboral> ofertasLaborales)
        {
            ID = iD;
            IdUsuario = idUsuario;
            Usuario = usuario;
            NombreEmpresa = nombreEmpresa;
            Descripcion = descripcion;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            Sector = sector;
            SitioWeb = sitioWeb;
            Tipo = tipo;
            FechaCreacion = fechaCreacion;
            Seguidores = seguidores;
            FotoPerfil = fotoPerfil;
            Publicaciones = publicaciones;
            CandidatosEmpresasConexiones = candidatosEmpresasConexiones;
            CandidatosSeguidoresEmpresas = candidatosSeguidoresEmpresas;
            EmpresasCandidatosSeguidores = empresasCandidatosSeguidores;
            EmpresasSeguidoresEmpresa = empresasSeguidoresEmpresa;
            OfertasLaborales = ofertasLaborales;
        }



        // Constructor que recibe todos los parámetros


















    }
}
