
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class OfertaLaboral
    {
        //PROPIEDADES
        public int ID { get; set; } // Identificador único de la oferta laboral
        public int IdEmpresa { get; set; } // Identificador de la empresa que publica la oferta laboral
        public virtual Empresa Empresa { get; set; } // Empresa que publica la oferta laboral
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string TipoContrato { get; set; } // Tipo de contrato (por ejemplo, "Tiempo completo", "Medio tiempo", "Temporal", etc.)
        public double SalarioMin { get; set; } // Salario mínimo ofrecido para la oferta laboral
        public double SalarioMax { get; set; } // Salario máximo ofrecido para la oferta laboral
        public DateTime FechaPublicacion { get; set; } // Fecha en que se publica la oferta laboral
        public DateTime FechaExpiracion { get; set; } // Fecha en que expira la oferta laboral

        public bool Disponible { get; set; } // Indica si la oferta laboral está disponible o no

        //uno a muchos
        public virtual ICollection<Habilidad> HabilidadesRequeridas { get; set; } 


        //Icollection
        public virtual ICollection<CandidatoOfertaLaboral> CandidadtosOfertas { get; set; } 




        // Constructor por defecto
        public OfertaLaboral()
        {
        }

        // Constructor que recibe todos los parámetros
        
        public OfertaLaboral(int id, int idEmpresa, Empresa empresa, string titulo, string descripcion, string ubicacion,
            string tipoContrato, double salarioMin, double salarioMax, DateTime fechaPublicacion, DateTime fechaExpiracion, bool disponible)
        {
            ID = id;
            IdEmpresa = idEmpresa;
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







    }
}
