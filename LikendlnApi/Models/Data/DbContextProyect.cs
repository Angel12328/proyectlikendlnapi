using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models.Data
{
    public class DbContextProyect : DbContext
    {
        public DbContextProyect() : base("name=DbContextProyect")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Habilidad> Habilidades { get; set; }
        public DbSet<MensajeBase> Mensajes { get; set; }
        public DbSet<MensajePrivado> MensajesPrivados { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Recomendacion> Recomendaciones { get; set; }
        public DbSet<OfertaLaboral> OfertasLaborales { get; set; }




    }
}