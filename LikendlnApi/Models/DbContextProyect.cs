
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LikendlnApi.Models
{
    public class DbContextProyect : DbContext
    {
        public DbContextProyect() : base("MyDbConnectionString")
        {
        }

        //DB Sets CLASES PRINCIPALES

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Habilidad> Habilidades { get; set; }
        
        public DbSet<MensajePrivado> MensajesPrivados { get; set; }
        public DbSet<MensajeEmpresarial> MensajesEmpresariales { get; set; }
        public DbSet<NotificacionMensaje> NotificacionesMensajes { get; set; }
        public DbSet<MiembroGrupo> MiembrosGrupos { get; set; }

        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Recomendacion> Recomendaciones { get; set; }
        public DbSet<OfertaLaboral> OfertasLaborales { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ParticipanteChat> ParticipanteChats { get; set; }
        
        public  DbSet<Curso> Cursos { get; set; }
        public DbSet<ExperienciaLaboral> ExperienciasLaborales { get; set; }

        public DbSet<SolicitudEmpleo> SolicitudEmpleos { get; set; }

        //DB Sets RELACIONES
        public DbSet<CandidatoCandidatoConexiones> CandidatoCandidatoConexiones { get; set; } 
        public DbSet<CandidatoEmpresaConexiones> CandidatoEmpresaConexiones { get; set; }
        public DbSet<CandidatoOfertaLaboral> CandidatosOfertaLaborales { get; set; }
        public DbSet<CandidatoGrupo> CandidatosGrupos { get; set; }
        public DbSet<CandidatoHabilidad> CandidatosHabilidades { get; set; }
        public DbSet<CandidatoSeguidorCandidato> CandidatoSeguidoresCandidatos { get; set; }
        public DbSet<CandidatoSeguidorEmpresa> CandidatosSeguidoresEmpresas { get; set; }
        public DbSet<EmpresaSeguidorCandidato> EmpresaSeguidoresCandidatos { get; set; }
        public DbSet<EmpresaSeguidorEmpresa> EmpresaSeguidoresEmpresas { get; set; }
        public DbSet<ChatParticipante> ChatParticipantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<MensajeEmpresarial>().ToTable("MensajesEmpresariales");
            modelBuilder.Entity<MensajePrivado>().ToTable("MensajesPrivados");            
            modelBuilder.Entity<Candidato>().ToTable("Candidatos");
        }


    }
}