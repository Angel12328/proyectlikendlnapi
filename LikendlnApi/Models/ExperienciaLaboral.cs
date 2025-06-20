using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models
{
    public class ExperienciaLaboral
    {
        //Atributos
        private int _idExperienciaLaboral;
        private string _empresa;
        private string _cargo;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private string _descripcion;

        //Constructor por defecto
        public ExperienciaLaboral()
        {
        }
        //Constructor que recibe todos los parametros
        public ExperienciaLaboral(int idExperienciaLaboral, string empresa, string cargo, DateTime fechaInicio, DateTime fechaFin, string descripcion)
        {
            IdExperienciaLaboral = idExperienciaLaboral;
            Empresa = empresa;
            Cargo = cargo;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Descripcion = descripcion;
        }
        //Setters y Getters
        public int IdExperienciaLaboral { get { return _idExperienciaLaboral; } set { _idExperienciaLaboral = value; } }
        public string Empresa { get { return _empresa; } set { _empresa = value; } }
        public string Cargo { get { return _cargo; } set { _cargo = value; } }
        public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public DateTime FechaFin { get { return _fechaFin; } set { _fechaFin = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        //Metodo ToString
        public override string ToString()
        {
            return $"Id: {IdExperienciaLaboral}, Empresa: {Empresa}, Cargo: {Cargo}, Fecha Inicio: {FechaInicio.ToShortDateString()}, Fecha Fin: {FechaFin.ToShortDateString()}, Descripcion: {Descripcion}";
        }
    }
}
