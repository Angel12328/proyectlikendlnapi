
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

            // Configuración de las relaciones entre entidades

            //Candidato -> ExperienciaLaboral

            //Candidato

            //Uno a muchos

            //Candidato -> ExperienciaLaboral
            modelBuilder.Entity<Candidato>()
                .HasMany(c => c.ExperienciasLaborales)
                .WithRequired(exp => exp.Candidato)
                .HasForeignKey(exp => exp.IdCandidato);

            //Candidato -> Publicacion
            modelBuilder.Entity<Candidato>()
                .HasMany(c => c.Publicaciones )
                .WithRequired(p=>p.Candidato)
                .HasForeignKey(p=> p.IdCandidato);
            //Candidato -> Curso
            modelBuilder.Entity<Candidato>()
                .HasMany(c => c.Cursos)
                .WithRequired(curso => curso.Candidato)
                .HasForeignKey(curso => curso.IdCandidato);
            //Muchos a muchos

            //Candidato -> CandidatoOfertaLaboral
            modelBuilder.Entity<Candidato>()
                .HasMany(co=> co.CandidadtosOfertas)
                .WithRequired(c=>c.Candidato)
                .HasForeignKey(c=>c.IdCandidato);

            //Candidato -> CandidatoGrupo

            modelBuilder.Entity<Candidato>()
                .HasMany(cg => cg.CandidatosGrupos)
                .WithRequired(c => c.Candidato)
                .HasForeignKey(c => c.IdCandidato);

            //Candidato -> CandidatoHabilidad
            modelBuilder.Entity<Candidato>()
                .HasMany(ch => ch.CandidatosHabilidades)
                .WithRequired(c => c.Candidato)
                .HasForeignKey(c => c.IdCandidato);
            //Candidato -> CandidatoCandidatoConexiones
            //para conexiones del candidato
            modelBuilder.Entity<Candidato>()
                .HasMany(ch => ch.CandidatosConexiones)
                .WithRequired(ccc => ccc.Candidato)
                .HasForeignKey(c => c.IdCandidato);
            //para conexion del candidato
            modelBuilder.Entity<Candidato>()
                .HasMany(ccc => ccc.CandidatosConexiones)
                .WithRequired(c => c.CandidatoConexion)
                .HasForeignKey(c => c.IdCandidatoConexion);
            //Candidato -> CandidatoEmpresaConexiones
            modelBuilder.Entity<Candidato>()
                .HasMany(cec => cec.CandidatosEmpresasConexiones)
                .WithRequired(c => c.Candidato)
                .HasForeignKey(c => c.IdCandidato);
            //Candidato -> CandidatoSeguidorCandidato
            modelBuilder.Entity<Candidato>()
                .HasMany(csc => csc.CandidatosSeguidores)
                .WithRequired(c => c.Candidato)
                .HasForeignKey(c => c.IdCandidato);
            //Candidato -> CandidatoSeguidorEmpresa
            modelBuilder.Entity<Candidato>()
                .HasMany(cse => cse.CandidatosSeguidoresEmpresas)
                .WithRequired(c => c.Candidato)
                .HasForeignKey(c => c.IdCandidato);
            //Candidato -> EmpresaSeguidorCandidato
            modelBuilder.Entity<Candidato>()
                .HasMany(esc => esc.EmpresasSeguidoresCandidatos)
                .WithRequired(c => c.Candidato)
                .HasForeignKey(c => c.IdCandidato);

            //Chat

            //uno a muchos

            //chat -> Mensaje
            modelBuilder.Entity<Chat>()
                .HasMany(m => m.Mensajes)
                .WithRequired(ch => ch.Chat)
                .HasForeignKey(ch => ch.IDChat);
            
            //muchos a muchos

            //Chat -> Participantes
            modelBuilder.Entity<Chat>()
                .HasMany(m => m.Participantes)
                .WithRequired(ch => ch.Chat)
                .HasForeignKey(ch => ch.ChatId);


            //Empresa

            //uno a muchos

            //Empresa -> Publicacion
            modelBuilder.Entity<Empresa>()
                .HasMany(pe => pe.Publicaciones)
                .WithRequired(e => e.Empresa)
                .HasForeignKey(e => e.IdEmpresa);

            //muchos a muchos

            //Empresa -> CandidatoEmpresaConexiones
            modelBuilder.Entity<Empresa>()
                .HasMany(cec => cec.CandidatosEmpresasConexiones)
                .WithRequired(e => e.Empresa)
                .HasForeignKey(e => e.IdEmpresa);
            //Empresa -> CandidatoSeguidorEmpresa
            modelBuilder.Entity<Empresa>()
                .HasMany(cse => cse.CandidatosSeguidoresEmpresas)
                .WithRequired(e => e.Empresa)
                .HasForeignKey(e => e.IdEmpresa);
            //Empresa -> EmpresaSeguidorCandidato
            modelBuilder.Entity<Empresa>()
                .HasMany(esc => esc.EmpresasCandidatosSeguidores)
                .WithRequired(e => e.Empresa)
                .HasForeignKey(e => e.IdEmpresa);
            //Empresa -> EmpresaSeguidorEmpresa
            //empresa que sigue a otra empresa
            modelBuilder.Entity<Empresa>()
                .HasMany(ese => ese.EmpresasSeguidoresEmpresa)
                .WithRequired(e => e.EmpresaSeguidora)
                .HasForeignKey(e => e.IdEmpresaSeguidora);
            //empresa que es seguida por otra empresa
            modelBuilder.Entity<Empresa>()
                .HasMany(ese => ese.EmpresasSeguidoresEmpresa)
                .WithRequired(e => e.EmpresaSeguido)
                .HasForeignKey(e => e.IdEmpresaSeguido);
            //Empresa -> OfertaLaboral
            modelBuilder.Entity<Empresa>()
                .HasMany(ese => ese.OfertasLaborales)
                .WithRequired(e => e.Empresa)
                .HasForeignKey(e => e.IdEmpresa);

            //Grupo

            //Muchos a muchos

            //Grupo -> MiembroGrupo
            modelBuilder.Entity<Grupo>()
                .HasMany(mg => mg.Miembros)
                .WithRequired(e => e.Grupo)
                .HasForeignKey(e => e.IDGrupo);

            //Grupo -> Publicacion
            modelBuilder.Entity<Grupo>()
                .HasMany(p => p.Publicaciones)
                .WithRequired(g => g.Grupo)
                .HasForeignKey(g => g.IdGrupo);

            //Grupo -> CandidatoGrupo
            modelBuilder.Entity<Grupo>()
                .HasMany(cg => cg.CandidadtosGrupos)
                .WithRequired(g => g.Grupo)
                .HasForeignKey(g => g.IdGrupo);

            //OfertaLaboral

            //muchos a muchos

            //OfertaLaboral - Habilidad

            modelBuilder.Entity<OfertaLaboral>()
                .HasMany(h => h.HabilidadesRequeridas)
                .WithRequired(h => h.OfertaLaboral)
                .HasForeignKey(h => h.IdOfertaLaboral);
            //OfertaLaboral - CandidatoOfertaLaboral
            modelBuilder.Entity<OfertaLaboral>()
                .HasMany(co => co.CandidadtosOfertas)
                .WithRequired(of => of.OfertaLaboral )
                .HasForeignKey(of => of.IdOfertaLaboral);

            //ParticipanteChat

            //uno a muchos

            //ParticipanteChat -> ParticipanteChat
            modelBuilder.Entity<ParticipanteChat>()
                .HasMany(pc => pc.Participantes)
                .WithRequired(p => p.ParticipanteChat)
                .HasForeignKey(p => p.ParticipanteId);

            //Publicacion

            //uno a muchos
            //Publicacion -> Comentario
            modelBuilder.Entity<Publicacion>()
                .HasMany(c => c.Comentarios)
                .WithRequired(p => p.Publicacion)
                .HasForeignKey(p => p.IdPublicacion);

            //Usuario

            //uno a muchos
            //Usuario -> Empresa
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Empresas)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuario);
        }


    }
}