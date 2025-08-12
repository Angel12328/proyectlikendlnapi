

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

        public DbSet<Curso> Cursos { get; set; }
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
        public DbSet<OfertaLaboralHabilidad> OfertasLaboralesHabilidades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MensajeEmpresarial>().ToTable("MensajesEmpresariales");
            modelBuilder.Entity<MensajePrivado>().ToTable("MensajesPrivados");
            modelBuilder.Entity<Candidato>().ToTable("Candidatos");
            modelBuilder.Entity<Publicacion>().ToTable("Publicaciones");

            /* TABLAS UNION RELACIONES*/

            //Uno a uno

            //CandidfatoCandidatoConexiones
            modelBuilder.Entity<CandidatoCandidatoConexiones>()
                .HasRequired(cg => cg.Candidato)
                .WithMany()
                .HasForeignKey(cg => cg.IdCandidato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CandidatoCandidatoConexiones>()
                .HasRequired(c => c.CandidatoConexion)
                .WithMany()
                .HasForeignKey(cg => cg.IdCandidatoConexion)
                .WillCascadeOnDelete(false);

            //CandidatoEmpresaConexiones
            modelBuilder.Entity<CandidatoEmpresaConexiones>()
                .HasRequired(c => c.Candidato)
                .WithMany()
                .HasForeignKey(cg => cg.IdCandidato)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CandidatoEmpresaConexiones>()
                .HasRequired(c => c.Empresa)
                .WithMany()
                .HasForeignKey(e => e.IdEmpresa)
                .WillCascadeOnDelete(false);

            //CandidatoGrupo
            // CandidatoGrupo: Relación entre Candidato y Grupo
            modelBuilder.Entity<CandidatoGrupo>()
                .HasRequired(cg => cg.Candidato)
                .WithMany()
                .HasForeignKey(cg => cg.IdCandidato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CandidatoGrupo>()
                .HasRequired(cg => cg.Grupo)
                .WithMany()
                .HasForeignKey(cg => cg.IdGrupo)
                .WillCascadeOnDelete(false);

            //CandidatoHabilidad
            // CandidatoGrupo: Relación entre Candidato y Grupo
            modelBuilder.Entity<CandidatoHabilidad>()
                .HasRequired(cg => cg.Candidato)
                .WithMany()
                .HasForeignKey(cg => cg.IdCandidato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CandidatoHabilidad>()
                .HasRequired(cg => cg.Habilidad)
                .WithMany()
                .HasForeignKey(cg => cg.IdHabilidad)
                .WillCascadeOnDelete(false);

            //CandidatoOfertaLaboral
            modelBuilder.Entity<CandidatoOfertaLaboral>()
                .HasRequired(c => c.Candidato)
                .WithMany()
                .HasForeignKey(of => of.IdCandidato)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CandidatoOfertaLaboral>()
                .HasRequired(c => c.OfertaLaboral)
                .WithMany()
                .HasForeignKey(of => of.IdOfertaLaboral)
                .WillCascadeOnDelete(false);

            //CandidatoSeguidorCandidato
            // Candidato que es seguido
            modelBuilder.Entity<CandidatoSeguidorCandidato>()
                .HasRequired(csc => csc.Candidato)
                .WithMany()
                .HasForeignKey(csc => csc.IdCandidato)
                .WillCascadeOnDelete(false);

            // Candidato que sigue (seguidor)
            modelBuilder.Entity<CandidatoSeguidorCandidato>()
                .HasRequired(csc => csc.Seguidor)
                .WithMany()
                .HasForeignKey(csc => csc.IdSeguidor)
                .WillCascadeOnDelete(false);

            //CandidatoSeguidorEmpresa
            modelBuilder.Entity<CandidatoSeguidorEmpresa>()
                .HasRequired(c => c.Candidato)
                .WithMany()
                .HasForeignKey(csc => csc.IdCandidato)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<CandidatoSeguidorEmpresa>()
                .HasRequired(c => c.Empresa)
                .WithMany()
                .HasForeignKey(csc => csc.IdEmpresa)
                .WillCascadeOnDelete(false);

            //ChatParticipante
            modelBuilder.Entity<ChatParticipante>()
                .HasRequired(cp => cp.Chat)
                .WithMany()
                .HasForeignKey(csc => csc.ChatId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ChatParticipante>()
                .HasRequired(cp => cp.ParticipanteChat)
                .WithMany()
                .HasForeignKey(csc => csc.ParticipanteId)
                .WillCascadeOnDelete(false);

            //EmpresaSeguidorCandidato
            modelBuilder.Entity<EmpresaSeguidorCandidato>()
                .HasRequired(e => e.Candidato)
                .WithMany()
                .HasForeignKey(csc => csc.IdCandidato)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<EmpresaSeguidorCandidato>()
                .HasRequired(e => e.Empresa)
                .WithMany()
                .HasForeignKey(csc => csc.IdEmpresa)
                .WillCascadeOnDelete(false);

            //EmpresaSeguidorEmpresa
            modelBuilder.Entity<EmpresaSeguidorEmpresa>()
                .HasRequired(e => e.EmpresaSeguidora)
                .WithMany()
                .HasForeignKey(csc => csc.IdEmpresaSeguidora)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<EmpresaSeguidorEmpresa>()
                .HasRequired(e => e.EmpresaSeguido)
                .WithMany()
                .HasForeignKey(csc => csc.IdEmpresaSeguido)
                .WillCascadeOnDelete(false);

            /*Entidades Relaciones propiedad compuesta*/

            //Uno a uno

            //Comentario
            modelBuilder.Entity<Comentario>()
                .HasOptional(c => c.AutorCandidato)
                .WithMany()
                .HasForeignKey(csc => csc.IdAutorCandidato)
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            modelBuilder.Entity<Comentario>()
                .HasOptional(c => c.AutorEmpresa)
                .WithMany()
                .HasForeignKey(csc => csc.IdAutorEmpresa)
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            modelBuilder.Entity<Comentario>()
                .HasRequired(c => c.Publicacion)
                .WithMany()
                .HasForeignKey(csc => csc.IdPublicacion)
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial

            //Curso
            modelBuilder.Entity<Curso>()
                .HasRequired(c => c.Candidato)
                .WithMany()
                .HasForeignKey(csc => csc.IdCandidato)
                .WillCascadeOnDelete(false);

            //Empresa
            modelBuilder.Entity<Empresa>()
                .HasRequired(e => e.Usuario)
                .WithMany()
                .HasForeignKey(csc => csc.IdUsuario)
                .WillCascadeOnDelete(false);
            //ExperienciaLaboral
            modelBuilder.Entity<ExperienciaLaboral>()
                .HasRequired(e => e.Candidato)
                .WithMany()
                .HasForeignKey(csc => csc.IdCandidato)
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            //Grupo
            modelBuilder.Entity<Grupo>()
                .HasOptional(c => c.CreadorCandidato)
                .WithMany()
                .HasForeignKey(csc => csc.IdCreadorCandidato)
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial
            modelBuilder.Entity<Grupo>()
                .HasOptional(c => c.CreadorEmpresa)
                .WithMany()
                .HasForeignKey(csc => csc.IdCreadorEmpresa)
                .WillCascadeOnDelete(false); // Evitar borrado en cascada para evitar problemas de integridad referencial


            //MensajeBase
            modelBuilder.Entity<MensajeBase>()
                .HasOptional(r => r.RemitenteCandidato)
                .WithMany()
                .HasForeignKey(csc => csc.IdRemitenteCandidato)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MensajeBase>()
                .HasOptional(r => r.RemitenteEmpresa)
                .WithMany()
                .HasForeignKey(csc => csc.IdRemitenteEmpresa)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MensajeBase>()
                .HasRequired(r => r.Chat)
                .WithMany()
                .HasForeignKey(csc => csc.IdChat)
                .WillCascadeOnDelete(false);

            //MensajeEmpresarial
            modelBuilder.Entity<MensajeEmpresarial>()
                .HasOptional(m => m.DestinatarioCandidato)
                .WithMany()
                .HasForeignKey(csc => csc.IDDestinatarioCandidato)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MensajeEmpresarial>()
                .HasOptional(m => m.DestinatarioEmpresa)
                .WithMany()
                .HasForeignKey(csc => csc.IDDestinatarioEmpresa)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MensajeEmpresarial>()
                .HasRequired(m => m.OfertaLaboralRelacinada)
                .WithMany()
                .HasForeignKey(csc => csc.IDOfertaLaboralRelacinada)
                .WillCascadeOnDelete(false);

            //MensajePrivado
            modelBuilder.Entity<MensajePrivado>()
                .HasRequired(m => m.DestinatarioCandidato)
                .WithMany()
                .HasForeignKey(csc => csc.IDDestinatarioCandidato)
                .WillCascadeOnDelete(false);

            //MiembroGrupo
            modelBuilder.Entity<MiembroGrupo>()
                .HasOptional(m => m.MiembroCandidato)  // Cambiado de HasRequired
                .WithMany()
                .HasForeignKey(csc => csc.IdMiembroCandidato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MiembroGrupo>()
                .HasOptional(m => m.MiembroEmpresa)  // Cambiado de HasRequired
                .WithMany()
                .HasForeignKey(csc => csc.IdMiembroEmpresa)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<MiembroGrupo>()
                .HasRequired(m => m.Grupo)
                .WithMany()
                .HasForeignKey(csc => csc.IdGrupo)
                .WillCascadeOnDelete(false);


            //NotificacionMensaje
            modelBuilder.Entity<NotificacionMensaje>()
                .HasOptional(n => n.Candidato)  // Cambiado de HasRequired
                .WithMany()
                .HasForeignKey(csc => csc.IDCandidato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NotificacionMensaje>()
                .HasOptional(n => n.Empresa)  // Cambiado de HasRequired
                .WithMany()
                .HasForeignKey(csc => csc.IDEmpresa)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<NotificacionMensaje>()
                .HasRequired(n => n.Mensaje)
                .WithMany()
                .HasForeignKey(csc => csc.IdMensajeBase)
                .WillCascadeOnDelete(false);

            // OfertaLaboral
            modelBuilder.Entity<OfertaLaboral>()
                .HasRequired(o => o.Empresa)  // Cambiado de HasRequired a HasOptional
                .WithMany()
                .HasForeignKey(s => s.IdEmpresa)
                .WillCascadeOnDelete(false); // Evitar borrado en cascada

            // ParticipanteChat
            modelBuilder.Entity<ParticipanteChat>()
                .HasOptional(p => p.ParticipanteCandidato)  // Cambiado de HasRequired a HasOptional
                .WithMany()
                .HasForeignKey(s => s.IdParticipanteCandidato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParticipanteChat>()
                .HasOptional(p => p.ParticipanteEmpresa)  // Cambiado de HasRequired a HasOptional
                .WithMany()
                .HasForeignKey(s => s.IdParticipanteEmpresa)
                .WillCascadeOnDelete(false);

            //Publicacion
            modelBuilder.Entity<Publicacion>()
                .HasOptional(p => p.Candidato)  // ← Cambiado de HasRequired
                .WithMany()
                .HasForeignKey(s => s.IdCandidato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publicacion>()
                .HasOptional(p => p.Empresa)  // ← Cambiado de HasRequired
                .WithMany()
                .HasForeignKey(s => s.IdEmpresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publicacion>()
                .HasOptional(p => p.Grupo)  // ← Cambiado de HasRequired
                .WithMany()
                .HasForeignKey(s => s.IdGrupo)
                .WillCascadeOnDelete(false);

            //Recomendacion
            modelBuilder.Entity<Recomendacion>()
                .HasOptional(r => r.Candidato)
                .WithMany()
                .HasForeignKey(s => s.IdCandidato)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Recomendacion>()
                .HasOptional(r => r.Empresa)
                .WithMany()
                .HasForeignKey(s => s.IdEmpresa)
                .WillCascadeOnDelete(false);

            //SolicitudEmpleo
            modelBuilder.Entity<SolicitudEmpleo>()
                .HasOptional(s => s.Candidato)
                .WithMany()
                .HasForeignKey(s => s.IdCandidato)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudEmpleo>()
                .HasOptional(s => s.Empresa)
                .WithMany()
                .HasForeignKey(s => s.IdEmpresa)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudEmpleo>()
                .HasRequired(s => s.OfertaLaboral)
                .WithMany()
                .HasForeignKey(s => s.IdOfertaLaboral)
                .WillCascadeOnDelete(false);


            /*--------------------------------------------------------------------------*/
            // Configuración de las relaciones entre entidades con Icollections

            //Candidato -> ExperienciaLaboral

            //Candidato

            // Uno a uno 
            modelBuilder.Entity<Candidato>()
                .HasRequired(c => c.Usuario)
                .WithMany()
                .HasForeignKey(s => s.IdUsuario)
                .WillCascadeOnDelete(false);



            //Uno a muchos

            //Candidato -> ExperienciaLaboral
            modelBuilder.Entity<Candidato>()
                .HasMany(c => c.ExperienciasLaborales)
                .WithRequired(exp => exp.Candidato)
                .HasForeignKey(exp => exp.IdCandidato);

            //Candidato -> Publicacion
            modelBuilder.Entity<Candidato>()
                .HasMany(c => c.Publicaciones)
                .WithOptional(p => p.Candidato)
                .HasForeignKey(p => p.IdCandidato);
            //Candidato -> Curso
            modelBuilder.Entity<Candidato>()
                .HasMany(c => c.Cursos)
                .WithRequired(curso => curso.Candidato)
                .HasForeignKey(curso => curso.IdCandidato);
            //Muchos a muchos

            //Candidato -> CandidatoOfertaLaboral
            modelBuilder.Entity<Candidato>()
                .HasMany(co => co.CandidadtosOfertas)
                .WithRequired(c => c.Candidato)
                .HasForeignKey(c => c.IdCandidato);

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
                .WithOptional(e => e.Empresa)
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
                .WithOptional(g => g.Grupo)
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
                .WithRequired(of => of.OfertaLaboral)
                .HasForeignKey(of => of.IdOfertaLaboral);

            //OfertaLaboral -> Habilidad
            modelBuilder.Entity<OfertaLaboral>()
                .HasMany(h => h.HabilidadesRequeridas)
                .WithRequired(h => h.OfertaLaboral)
                .HasForeignKey(h => h.IdOfertaLaboral);

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

            //Habilidad
            //muchos a muchos
            //Habilidad -> OfertaLaboralHabilidad
            modelBuilder.Entity<Habilidad>()
                .HasMany(olh => olh.HabilidadesRequeridas)
                .WithRequired(h => h.Habilidad)
                .HasForeignKey(h => h.IdHabilidad);


        }


    }
}
