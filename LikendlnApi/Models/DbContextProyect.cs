
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
        
        //public DbSet<MensajeBase> MensajeBases { get; set; }
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MensajeEmpresarial>().ToTable("MensajesEmpresariales");
            modelBuilder.Entity<MensajePrivado>().ToTable("MensajesPrivados");            
            modelBuilder.Entity<Candidato>().ToTable("Candidatos");

            /* TABLAS UNION RELACIONES*/

            //Uno a uno

            //CandidfatoCandidatoConexiones
            modelBuilder.Entity<CandidatoCandidatoConexiones>()
                .HasRequired(c => c.Candidato)
                .WithOptional();

            modelBuilder.Entity<CandidatoCandidatoConexiones>()
                .HasRequired(c => c.CandidatoConexion)
                .WithOptional();

            //CandidatoEmpresaConexiones
            modelBuilder.Entity<CandidatoEmpresaConexiones>()
                .HasRequired(c => c.Candidato)
                .WithOptional();
            modelBuilder.Entity<CandidatoEmpresaConexiones>()
                .HasRequired(c => c.Empresa)
                .WithOptional();

            //CandidatoGrupo
            modelBuilder.Entity<CandidatoGrupo>()
                .HasRequired(c => c.Candidato)
                .WithOptional();
            modelBuilder.Entity<CandidatoGrupo>()
                .HasRequired(c => c.Grupo)
                .WithOptional();

            //CandidatoHabilidad
            modelBuilder.Entity<CandidatoHabilidad>()
                .HasRequired(c => c.Candidato)
                .WithOptional();
            modelBuilder.Entity<CandidatoHabilidad>()
                .HasRequired(c => c.Habilidad)
                .WithOptional();

            //CandidatoOfertaLaboral
            modelBuilder.Entity<CandidatoOfertaLaboral>()
                .HasRequired(c => c.Candidato)
                .WithOptional();
            modelBuilder.Entity<CandidatoOfertaLaboral>()
                .HasRequired(c => c.OfertaLaboral)
                .WithOptional();

            //CandidatoSeguidorCandidato
            modelBuilder.Entity<CandidatoSeguidorCandidato>()
                .HasRequired(c => c.Candidato)
                .WithOptional();
            modelBuilder.Entity<CandidatoSeguidorCandidato>()
                .HasRequired(c => c.Seguidor)
                .WithOptional();

            //CandidatoSeguidorEmpresa
            modelBuilder.Entity<CandidatoSeguidorEmpresa>()
                .HasRequired(c => c.Candidato)
                .WithOptional();
            modelBuilder.Entity<CandidatoSeguidorEmpresa>()
                .HasRequired(c => c.Empresa)
                .WithOptional();

            //ChatParticipante
            modelBuilder.Entity<ChatParticipante>()
                .HasRequired(cp => cp.Chat)
                .WithOptional();
            modelBuilder.Entity<ChatParticipante>()
                .HasRequired(cp => cp.ParticipanteChat)
                .WithOptional();

            //EmpresaSeguidorCandidato
            modelBuilder.Entity<EmpresaSeguidorCandidato>()
                .HasRequired(e => e.Candidato)
                .WithOptional();
            modelBuilder.Entity<EmpresaSeguidorCandidato>()
                .HasRequired(e => e.Empresa)
                .WithOptional();

            //EmpresaSeguidorEmpresa
            modelBuilder.Entity<EmpresaSeguidorEmpresa>()
                .HasRequired(e => e.EmpresaSeguidora)
                .WithOptional();
            modelBuilder.Entity<EmpresaSeguidorEmpresa>()
                .HasRequired(e => e.EmpresaSeguido)
                .WithOptional();

            /*Entidades Relaciones propiedad compuesta*/

            //Uno a uno

            //Comentario
            modelBuilder.Entity<Comentario>()
                .HasRequired(c => c.AutorCandidato)
                .WithOptional()
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            modelBuilder.Entity<Comentario>()
                .HasRequired(c => c.AutorEmpresa)
                .WithOptional()
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            modelBuilder.Entity<Comentario>()
                .HasRequired(c => c.Publicacion)
                .WithOptional()
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial

            //Curso
            modelBuilder.Entity<Curso>()
                .HasRequired(c => c.Candidato)
                .WithOptional()
                .WillCascadeOnDelete(false);

            //Empresa
            modelBuilder.Entity<Empresa>()
                .HasRequired(e => e.Usuario)
                .WithOptional();
            //ExperienciaLaboral
            modelBuilder.Entity<ExperienciaLaboral>()
                .HasRequired(e => e.Candidato)
                .WithOptional()
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            //Grupo
            modelBuilder.Entity<Grupo>()
                .HasRequired(c =>c.CreadorCandidato)
                .WithOptional()
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            modelBuilder.Entity<Grupo>()
                .HasRequired(c =>c.CreadorEmpresa)
                .WithOptional()
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            
            //Habilidad
            modelBuilder.Entity<Habilidad>()
                .HasRequired(c => c.Candidato)
                .WithOptional()
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            modelBuilder.Entity<Habilidad>()
                .HasRequired(c => c.OfertaLaboral)
                .WithOptional()
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial

            //MensajeBase
            modelBuilder.Entity<MensajeBase>()
                .HasRequired(r => r.RemitenteCandidato) 
                .WithOptional()
                .WillCascadeOnDelete(false); 
            modelBuilder.Entity<MensajeBase>()
                .HasRequired(r => r.RemitenteEmpresa) 
                .WithOptional()
                .WillCascadeOnDelete(false); 
            modelBuilder.Entity<MensajeBase>()
                .HasRequired(r => r.Chat) 
                .WithOptional()
                .WillCascadeOnDelete(false);

            //MensajeEmpresarial
            modelBuilder.Entity<MensajeEmpresarial>()
                .HasRequired(m => m.DestinatarioCandidato)
                .WithOptional()
                .WillCascadeOnDelete(false); 
            modelBuilder.Entity<MensajeEmpresarial>()
                .HasRequired(m => m.DestinatarioEmpresa)
                .WithOptional()
                .WillCascadeOnDelete(false); 
            modelBuilder.Entity<MensajeEmpresarial>()
                .HasRequired(m => m.OfertaLaboralRelacinada)
                .WithOptional()
                .WillCascadeOnDelete(false);

            //MensajePrivado
            modelBuilder.Entity<MensajePrivado>()
                .HasRequired(m => m.DestinatarioCandidato)
                .WithOptional()
                .WillCascadeOnDelete(false);

            //MiembroGrupo
            modelBuilder.Entity<MiembroGrupo>()
                .HasRequired(m => m.MiembroCandidato)
                .WithOptional()
                .WillCascadeOnDelete(false); 
            modelBuilder.Entity<MiembroGrupo>()
                .HasRequired(m => m.MiembroEmpresa)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MiembroGrupo>()
                .HasRequired(m => m.Grupo)
                .WithOptional()
                .WillCascadeOnDelete(false);


            //NotificacionMensaje
            modelBuilder.Entity<NotificacionMensaje>()
                .HasRequired(n => n.Candidato)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<NotificacionMensaje>()
                .HasRequired(n => n.Empresa)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<NotificacionMensaje>()
                .HasRequired(n => n.Mensaje)
                .WithOptional()
                .WillCascadeOnDelete(false);

            //OfertaLaboral
            modelBuilder.Entity<OfertaLaboral>()
                .HasRequired(o => o.Empresa)
                .WithOptional()
                .WillCascadeOnDelete(false); // Evitar borrado en cascada

            //ParticipanteChat
            modelBuilder.Entity<ParticipanteChat>()
                .HasRequired(p => p.ParticipanteCandidato)
                .WithOptional()
                .WillCascadeOnDelete(false); 
            modelBuilder.Entity<ParticipanteChat>()
                .HasRequired(p => p.ParticipanteEmpresa)
                .WithOptional()
                .WillCascadeOnDelete(false);

            //Publicacion
            modelBuilder.Entity<Publicacion>()
                .HasRequired(p => p.Candidato)
                .WithOptional()
                .WillCascadeOnDelete(false); 
            modelBuilder.Entity<Publicacion>()
                .HasRequired(p => p.Empresa)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Publicacion>()
                .HasRequired(p => p.Grupo)
                .WithOptional()
                .WillCascadeOnDelete(false);

            //Recomendacion
            modelBuilder.Entity<Recomendacion>()
                .HasRequired(r => r.Candidato)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Recomendacion>()
                .HasRequired(r => r.Empresa)
                .WithOptional()
                .WillCascadeOnDelete(false);

            //SolicitudEmpleo
            modelBuilder.Entity<SolicitudEmpleo>()
                .HasRequired(s => s.Candidato)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudEmpleo>()
                .HasRequired(s => s.Empresa)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudEmpleo>()
                .HasRequired(s => s.OfertaLaboral)
                .WithOptional()
                .WillCascadeOnDelete(false);


            /*--------------------------------------------------------------------------*/
            // Configuración de las relaciones entre entidades con Icollections

            //Candidato -> ExperienciaLaboral

            //Candidato

            // Uno a uno 
            modelBuilder.Entity<Candidato>()
                .HasRequired(c => c.Usuario)    
                .WithOptional();
                


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
                .HasForeignKey(ch => ch.IdChat);
            
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
                .HasForeignKey(e => e.IdGrupo);

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