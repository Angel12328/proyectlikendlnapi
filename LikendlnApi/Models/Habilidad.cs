using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikendlnApi.Models.Data
{
    public class Habilidad
    {
        //atributos
        private int _idHabilidad;
        private string _nombre;
        private string _descripcion;
        private string _categoria;
        private string _nivel; // Ejemplo: "Básico", "Intermedio", "Avanzado"

        // Constructor por defecto
        public Habilidad()
        {
        }

        // Constructor que recibe todos los parámetros
        public Habilidad(int idHabilidad, string nombre, string descripcion, string categoria, string nivel)
        {
            IdHabilidad = idHabilidad;
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            Nivel = nivel;
        }

        // Setters y Getters

        public int IdHabilidad { get { return _idHabilidad; } set { _idHabilidad = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string Categoria { get { return _categoria; } set { _categoria = value; } }
        public string Nivel { get { return _nivel; } set { _nivel = value; } }

       //toString
        public override string ToString()
        {
            return $"Id: {IdHabilidad}, Nombre: {Nombre}, Descripcion: {Descripcion}, Categoria: {Categoria}, Nivel: {Nivel}";
        }



    }
}
