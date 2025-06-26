using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Relaciones
{
    public class EmpresaSeguidorEmpresa
    {
        public int Id { get; set; } // Identificador único de la relación
        public int IdEmpresaSeguidora { get; set; } // Identificador de la empresa que sigue a otra empresa
        public Empresa EmpresaSeguidora { get; set; } // Empresa que sigue a otra empresa
        public int IdEmpresaSeguido { get; set; } // Identificador de la empresa que es seguida
        public Empresa EmpresaSeguido { get; set; } // Empresa que es seguida
        // Constructor por defecto
        public EmpresaSeguidorEmpresa()
        {
        }
        // Constructor que recibe todos los parámetros
        public EmpresaSeguidorEmpresa(int id, int idEmpresaSeguidora, Empresa empresaSeguidora, int idEmpresaSeguido, Empresa empresaSeguido)
        {
            Id = id;
            IdEmpresaSeguidora = idEmpresaSeguidora;
            EmpresaSeguidora = empresaSeguidora;
            IdEmpresaSeguido = idEmpresaSeguido;
            EmpresaSeguido = empresaSeguido;
        }
    }
}