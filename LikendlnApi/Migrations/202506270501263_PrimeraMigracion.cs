namespace LikendlnApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidatoCandidatoConexiones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdCandidatoConexion = c.Int(nullable: false),
                        Candidato_Id = c.Int(),
                        Candidato_Id1 = c.Int(),
                        CandidatoConexion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id1)
                .ForeignKey("dbo.Candidatos", t => t.CandidatoConexion_Id)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Candidato_Id1)
                .Index(t => t.CandidatoConexion_Id);
            
            CreateTable(
                "dbo.Candidatos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        TituloProfesional = c.String(),
                        CurriculumVitae = c.String(),
                        Seguidores = c.Int(nullable: false),
                        FotoPerfil = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        CoreoElectronico = c.String(),
                        Telefono = c.String(),
                        Usuario_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_ID)
                .Index(t => t.Usuario_ID);
            
            CreateTable(
                "dbo.CandidatoOfertaLaborals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdOfertaLaboral = c.Int(nullable: false),
                        Candidato_Id = c.Int(),
                        OfertaLaboral_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.OfertaLaborals", t => t.OfertaLaboral_ID)
                .Index(t => t.Candidato_Id)
                .Index(t => t.OfertaLaboral_ID);
            
            CreateTable(
                "dbo.OfertaLaborals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdEmpresa = c.Int(nullable: false),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        Ubicacion = c.String(),
                        TipoContrato = c.String(),
                        SalarioMin = c.Double(nullable: false),
                        SalarioMax = c.Double(nullable: false),
                        FechaPublicacion = c.DateTime(nullable: false),
                        FechaExpiracion = c.DateTime(nullable: false),
                        Disponible = c.Boolean(nullable: false),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.Empresa_ID);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        NombreEmpresa = c.String(),
                        Descripcion = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        CorreoElectronico = c.String(),
                        Sector = c.String(),
                        SitioWeb = c.String(),
                        Tipo = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        Seguidores = c.Int(nullable: false),
                        FotoPerfil = c.String(),
                        Usuario_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_ID)
                .Index(t => t.Usuario_ID);
            
            CreateTable(
                "dbo.CandidatoEmpresaConexiones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                        Candidato_Id = c.Int(),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Empresa_ID);
            
            CreateTable(
                "dbo.EmpresaSeguidorCandidatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEmpresa = c.Int(nullable: false),
                        IdCandidato = c.Int(nullable: false),
                        Candidato_Id = c.Int(),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Empresa_ID);
            
            CreateTable(
                "dbo.CandidatoSeguidorEmpresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                        Candidato_Id = c.Int(),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Empresa_ID);
            
            CreateTable(
                "dbo.EmpresaSeguidorEmpresas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEmpresaSeguidora = c.Int(nullable: false),
                        IdEmpresaSeguido = c.Int(nullable: false),
                        EmpresaSeguido_ID = c.Int(),
                        EmpresaSeguidora_ID = c.Int(),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresas", t => t.EmpresaSeguido_ID)
                .ForeignKey("dbo.Empresas", t => t.EmpresaSeguidora_ID)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.EmpresaSeguido_ID)
                .Index(t => t.EmpresaSeguidora_ID)
                .Index(t => t.Empresa_ID);
            
            CreateTable(
                "dbo.Publicacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                        IdGrupo = c.Int(nullable: false),
                        Contenido = c.String(),
                        FechaPublicacion = c.DateTime(nullable: false),
                        ImagenURL = c.String(),
                        Candidato_Id = c.Int(),
                        Empresa_ID = c.Int(),
                        Grupo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .ForeignKey("dbo.Grupoes", t => t.Grupo_ID)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Empresa_ID)
                .Index(t => t.Grupo_ID);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        IdCandidato = c.Int(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                        IdPublicacion = c.Int(nullable: false),
                        AutorCandidato_Id = c.Int(),
                        AutorEmpresa_ID = c.Int(),
                        Publicacion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.AutorCandidato_Id)
                .ForeignKey("dbo.Empresas", t => t.AutorEmpresa_ID)
                .ForeignKey("dbo.Publicacions", t => t.Publicacion_Id)
                .Index(t => t.AutorCandidato_Id)
                .Index(t => t.AutorEmpresa_ID)
                .Index(t => t.Publicacion_Id);
            
            CreateTable(
                "dbo.Grupoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDCreador = c.Int(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                        FotoPerfil = c.String(),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        EsPrivado = c.Boolean(nullable: false),
                        CreadorCandidato_Id = c.Int(),
                        CreadorEmpresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.CreadorCandidato_Id)
                .ForeignKey("dbo.Empresas", t => t.CreadorEmpresa_ID)
                .Index(t => t.CreadorCandidato_Id)
                .Index(t => t.CreadorEmpresa_ID);
            
            CreateTable(
                "dbo.CandidatoGrupoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdGrupo = c.Int(nullable: false),
                        Candidato_Id = c.Int(),
                        Grupo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Grupoes", t => t.Grupo_ID)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Grupo_ID);
            
            CreateTable(
                "dbo.MiembroGrupoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FechaUnion = c.DateTime(nullable: false),
                        IDMiembroCandidato = c.Int(nullable: false),
                        IDMiembroEmpresa = c.Int(nullable: false),
                        IDGrupo = c.Int(nullable: false),
                        RolGrupo = c.String(),
                        Grupo_ID = c.Int(),
                        MiembroCandidato_Id = c.Int(),
                        MiembroEmpresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Grupoes", t => t.Grupo_ID)
                .ForeignKey("dbo.Candidatos", t => t.MiembroCandidato_Id)
                .ForeignKey("dbo.Empresas", t => t.MiembroEmpresa_ID)
                .Index(t => t.Grupo_ID)
                .Index(t => t.MiembroCandidato_Id)
                .Index(t => t.MiembroEmpresa_ID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContrasenIa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Habilidads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdOfertaLaboral = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Categoria = c.String(),
                        Nivel = c.String(),
                        Candidato_Id = c.Int(),
                        OfertaLaboral_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.OfertaLaborals", t => t.OfertaLaboral_ID)
                .Index(t => t.Candidato_Id)
                .Index(t => t.OfertaLaboral_ID);
            
            CreateTable(
                "dbo.CandidatoHabilidads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdHabilidad = c.Int(nullable: false),
                        Candidato_Id = c.Int(),
                        Habilidad_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Habilidads", t => t.Habilidad_ID)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Habilidad_ID);
            
            CreateTable(
                "dbo.CandidatoSeguidorCandidatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdSeguidor = c.Int(nullable: false),
                        Candidato_Id = c.Int(),
                        Seguidor_Id = c.Int(),
                        Candidato_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Candidatos", t => t.Seguidor_Id)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id1)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Seguidor_Id)
                .Index(t => t.Candidato_Id1);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Institucion = c.String(),
                        IdCredencial = c.Int(nullable: false),
                        UrlCertificado = c.String(),
                        Candidato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.ExperienciaLaborals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        Empresa = c.String(),
                        Cargo = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        Candidato_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.ChatParticipantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChatId = c.Int(nullable: false),
                        ParticipanteId = c.Int(nullable: false),
                        ParticipanteChat_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.ParticipanteChats", t => t.ParticipanteChat_ID)
                .Index(t => t.ChatId)
                .Index(t => t.ParticipanteChat_ID);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        UltimaActividad = c.DateTime(nullable: false),
                        Titulo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MensajeBases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaEnvio = c.DateTime(nullable: false),
                        IDCandidato = c.Int(nullable: false),
                        IDEmpresa = c.Int(nullable: false),
                        IDChat = c.Int(nullable: false),
                        Contenido = c.String(),
                        Leido = c.Boolean(nullable: false),
                        Chat_ID = c.Int(),
                        RemitenteCandidato_Id = c.Int(),
                        RemitenteEmpresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.Chat_ID)
                .ForeignKey("dbo.Candidatos", t => t.RemitenteCandidato_Id)
                .ForeignKey("dbo.Empresas", t => t.RemitenteEmpresa_ID)
                .Index(t => t.Chat_ID)
                .Index(t => t.RemitenteCandidato_Id)
                .Index(t => t.RemitenteEmpresa_ID);
            
            CreateTable(
                "dbo.ParticipanteChats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FechaUnion = c.DateTime(nullable: false),
                        IdCandidato = c.Int(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                        ParticipanteCandidato_Id = c.Int(),
                        ParticipanteEmpresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.ParticipanteCandidato_Id)
                .ForeignKey("dbo.Empresas", t => t.ParticipanteEmpresa_ID)
                .Index(t => t.ParticipanteCandidato_Id)
                .Index(t => t.ParticipanteEmpresa_ID);
            
            CreateTable(
                "dbo.NotificacionMensajes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FechaNotificacion = c.DateTime(nullable: false),
                        IDCandidato = c.Int(nullable: false),
                        IDEmpresa = c.Int(nullable: false),
                        IdMensajeBase = c.Int(nullable: false),
                        Leido = c.Boolean(nullable: false),
                        Candidato_Id = c.Int(),
                        Empresa_ID = c.Int(),
                        Mensaje_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .ForeignKey("dbo.MensajeBases", t => t.Mensaje_Id)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Empresa_ID)
                .Index(t => t.Mensaje_Id);
            
            CreateTable(
                "dbo.Recomendacions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDCandidato = c.Int(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                        Mensaje = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Empresa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .Index(t => t.Empresa_ID);
            
            CreateTable(
                "dbo.SolicitudEmpleos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdCandidato = c.Int(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        IdOfertaLaboral = c.Int(nullable: false),
                        FechaSolicitud = c.DateTime(nullable: false),
                        Estado = c.String(),
                        Candidato_Id = c.Int(),
                        Empresa_ID = c.Int(),
                        OfertaLaboral_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidatos", t => t.Candidato_Id)
                .ForeignKey("dbo.Empresas", t => t.Empresa_ID)
                .ForeignKey("dbo.OfertaLaborals", t => t.OfertaLaboral_ID)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Empresa_ID)
                .Index(t => t.OfertaLaboral_ID);
            
            CreateTable(
                "dbo.MensajesEmpresariales",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DestinatarioCandidato_Id = c.Int(),
                        DestinatarioEmpresa_ID = c.Int(),
                        OfertaLaboralRelacinada_ID = c.Int(),
                        IDCandidatoDestinatario = c.Int(nullable: false),
                        IDDestinatarioEmpresa = c.Int(nullable: false),
                        IDOfertaLbrl = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MensajeBases", t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.DestinatarioCandidato_Id)
                .ForeignKey("dbo.Empresas", t => t.DestinatarioEmpresa_ID)
                .ForeignKey("dbo.OfertaLaborals", t => t.OfertaLaboralRelacinada_ID)
                .Index(t => t.Id)
                .Index(t => t.DestinatarioCandidato_Id)
                .Index(t => t.DestinatarioEmpresa_ID)
                .Index(t => t.OfertaLaboralRelacinada_ID);
            
            CreateTable(
                "dbo.MensajesPrivados",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DestinatarioCandidato_Id = c.Int(),
                        IDDestinatarioCandidato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MensajeBases", t => t.Id)
                .ForeignKey("dbo.Candidatos", t => t.DestinatarioCandidato_Id)
                .Index(t => t.Id)
                .Index(t => t.DestinatarioCandidato_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MensajesPrivados", "DestinatarioCandidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.MensajesPrivados", "Id", "dbo.MensajeBases");
            DropForeignKey("dbo.MensajesEmpresariales", "OfertaLaboralRelacinada_ID", "dbo.OfertaLaborals");
            DropForeignKey("dbo.MensajesEmpresariales", "DestinatarioEmpresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.MensajesEmpresariales", "DestinatarioCandidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.MensajesEmpresariales", "Id", "dbo.MensajeBases");
            DropForeignKey("dbo.SolicitudEmpleos", "OfertaLaboral_ID", "dbo.OfertaLaborals");
            DropForeignKey("dbo.SolicitudEmpleos", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.SolicitudEmpleos", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Recomendacions", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.NotificacionMensajes", "Mensaje_Id", "dbo.MensajeBases");
            DropForeignKey("dbo.NotificacionMensajes", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.NotificacionMensajes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.ChatParticipantes", "ParticipanteChat_ID", "dbo.ParticipanteChats");
            DropForeignKey("dbo.ParticipanteChats", "ParticipanteEmpresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.ParticipanteChats", "ParticipanteCandidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.ChatParticipantes", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.MensajeBases", "RemitenteEmpresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.MensajeBases", "RemitenteCandidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.MensajeBases", "Chat_ID", "dbo.Chats");
            DropForeignKey("dbo.CandidatoCandidatoConexiones", "CandidatoConexion_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatoCandidatoConexiones", "Candidato_Id1", "dbo.Candidatos");
            DropForeignKey("dbo.Candidatos", "Usuario_ID", "dbo.Usuarios");
            DropForeignKey("dbo.ExperienciaLaborals", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Cursoes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatoSeguidorCandidatoes", "Candidato_Id1", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatoSeguidorCandidatoes", "Seguidor_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatoSeguidorCandidatoes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatoHabilidads", "Habilidad_ID", "dbo.Habilidads");
            DropForeignKey("dbo.CandidatoHabilidads", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatoCandidatoConexiones", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Habilidads", "OfertaLaboral_ID", "dbo.OfertaLaborals");
            DropForeignKey("dbo.Habilidads", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Empresas", "Usuario_ID", "dbo.Usuarios");
            DropForeignKey("dbo.Publicacions", "Grupo_ID", "dbo.Grupoes");
            DropForeignKey("dbo.MiembroGrupoes", "MiembroEmpresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.MiembroGrupoes", "MiembroCandidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.MiembroGrupoes", "Grupo_ID", "dbo.Grupoes");
            DropForeignKey("dbo.Grupoes", "CreadorEmpresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.Grupoes", "CreadorCandidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatoGrupoes", "Grupo_ID", "dbo.Grupoes");
            DropForeignKey("dbo.CandidatoGrupoes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Publicacions", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.Comentarios", "Publicacion_Id", "dbo.Publicacions");
            DropForeignKey("dbo.Comentarios", "AutorEmpresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.Comentarios", "AutorCandidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.Publicacions", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.OfertaLaborals", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.EmpresaSeguidorEmpresas", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.EmpresaSeguidorEmpresas", "EmpresaSeguidora_ID", "dbo.Empresas");
            DropForeignKey("dbo.EmpresaSeguidorEmpresas", "EmpresaSeguido_ID", "dbo.Empresas");
            DropForeignKey("dbo.CandidatoSeguidorEmpresas", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.CandidatoSeguidorEmpresas", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.EmpresaSeguidorCandidatoes", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.EmpresaSeguidorCandidatoes", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatoEmpresaConexiones", "Empresa_ID", "dbo.Empresas");
            DropForeignKey("dbo.CandidatoEmpresaConexiones", "Candidato_Id", "dbo.Candidatos");
            DropForeignKey("dbo.CandidatoOfertaLaborals", "OfertaLaboral_ID", "dbo.OfertaLaborals");
            DropForeignKey("dbo.CandidatoOfertaLaborals", "Candidato_Id", "dbo.Candidatos");
            DropIndex("dbo.MensajesPrivados", new[] { "DestinatarioCandidato_Id" });
            DropIndex("dbo.MensajesPrivados", new[] { "Id" });
            DropIndex("dbo.MensajesEmpresariales", new[] { "OfertaLaboralRelacinada_ID" });
            DropIndex("dbo.MensajesEmpresariales", new[] { "DestinatarioEmpresa_ID" });
            DropIndex("dbo.MensajesEmpresariales", new[] { "DestinatarioCandidato_Id" });
            DropIndex("dbo.MensajesEmpresariales", new[] { "Id" });
            DropIndex("dbo.SolicitudEmpleos", new[] { "OfertaLaboral_ID" });
            DropIndex("dbo.SolicitudEmpleos", new[] { "Empresa_ID" });
            DropIndex("dbo.SolicitudEmpleos", new[] { "Candidato_Id" });
            DropIndex("dbo.Recomendacions", new[] { "Empresa_ID" });
            DropIndex("dbo.NotificacionMensajes", new[] { "Mensaje_Id" });
            DropIndex("dbo.NotificacionMensajes", new[] { "Empresa_ID" });
            DropIndex("dbo.NotificacionMensajes", new[] { "Candidato_Id" });
            DropIndex("dbo.ParticipanteChats", new[] { "ParticipanteEmpresa_ID" });
            DropIndex("dbo.ParticipanteChats", new[] { "ParticipanteCandidato_Id" });
            DropIndex("dbo.MensajeBases", new[] { "RemitenteEmpresa_ID" });
            DropIndex("dbo.MensajeBases", new[] { "RemitenteCandidato_Id" });
            DropIndex("dbo.MensajeBases", new[] { "Chat_ID" });
            DropIndex("dbo.ChatParticipantes", new[] { "ParticipanteChat_ID" });
            DropIndex("dbo.ChatParticipantes", new[] { "ChatId" });
            DropIndex("dbo.ExperienciaLaborals", new[] { "Candidato_Id" });
            DropIndex("dbo.Cursoes", new[] { "Candidato_Id" });
            DropIndex("dbo.CandidatoSeguidorCandidatoes", new[] { "Candidato_Id1" });
            DropIndex("dbo.CandidatoSeguidorCandidatoes", new[] { "Seguidor_Id" });
            DropIndex("dbo.CandidatoSeguidorCandidatoes", new[] { "Candidato_Id" });
            DropIndex("dbo.CandidatoHabilidads", new[] { "Habilidad_ID" });
            DropIndex("dbo.CandidatoHabilidads", new[] { "Candidato_Id" });
            DropIndex("dbo.Habilidads", new[] { "OfertaLaboral_ID" });
            DropIndex("dbo.Habilidads", new[] { "Candidato_Id" });
            DropIndex("dbo.MiembroGrupoes", new[] { "MiembroEmpresa_ID" });
            DropIndex("dbo.MiembroGrupoes", new[] { "MiembroCandidato_Id" });
            DropIndex("dbo.MiembroGrupoes", new[] { "Grupo_ID" });
            DropIndex("dbo.CandidatoGrupoes", new[] { "Grupo_ID" });
            DropIndex("dbo.CandidatoGrupoes", new[] { "Candidato_Id" });
            DropIndex("dbo.Grupoes", new[] { "CreadorEmpresa_ID" });
            DropIndex("dbo.Grupoes", new[] { "CreadorCandidato_Id" });
            DropIndex("dbo.Comentarios", new[] { "Publicacion_Id" });
            DropIndex("dbo.Comentarios", new[] { "AutorEmpresa_ID" });
            DropIndex("dbo.Comentarios", new[] { "AutorCandidato_Id" });
            DropIndex("dbo.Publicacions", new[] { "Grupo_ID" });
            DropIndex("dbo.Publicacions", new[] { "Empresa_ID" });
            DropIndex("dbo.Publicacions", new[] { "Candidato_Id" });
            DropIndex("dbo.EmpresaSeguidorEmpresas", new[] { "Empresa_ID" });
            DropIndex("dbo.EmpresaSeguidorEmpresas", new[] { "EmpresaSeguidora_ID" });
            DropIndex("dbo.EmpresaSeguidorEmpresas", new[] { "EmpresaSeguido_ID" });
            DropIndex("dbo.CandidatoSeguidorEmpresas", new[] { "Empresa_ID" });
            DropIndex("dbo.CandidatoSeguidorEmpresas", new[] { "Candidato_Id" });
            DropIndex("dbo.EmpresaSeguidorCandidatoes", new[] { "Empresa_ID" });
            DropIndex("dbo.EmpresaSeguidorCandidatoes", new[] { "Candidato_Id" });
            DropIndex("dbo.CandidatoEmpresaConexiones", new[] { "Empresa_ID" });
            DropIndex("dbo.CandidatoEmpresaConexiones", new[] { "Candidato_Id" });
            DropIndex("dbo.Empresas", new[] { "Usuario_ID" });
            DropIndex("dbo.OfertaLaborals", new[] { "Empresa_ID" });
            DropIndex("dbo.CandidatoOfertaLaborals", new[] { "OfertaLaboral_ID" });
            DropIndex("dbo.CandidatoOfertaLaborals", new[] { "Candidato_Id" });
            DropIndex("dbo.Candidatos", new[] { "Usuario_ID" });
            DropIndex("dbo.CandidatoCandidatoConexiones", new[] { "CandidatoConexion_Id" });
            DropIndex("dbo.CandidatoCandidatoConexiones", new[] { "Candidato_Id1" });
            DropIndex("dbo.CandidatoCandidatoConexiones", new[] { "Candidato_Id" });
            DropTable("dbo.MensajesPrivados");
            DropTable("dbo.MensajesEmpresariales");
            DropTable("dbo.SolicitudEmpleos");
            DropTable("dbo.Recomendacions");
            DropTable("dbo.NotificacionMensajes");
            DropTable("dbo.ParticipanteChats");
            DropTable("dbo.MensajeBases");
            DropTable("dbo.Chats");
            DropTable("dbo.ChatParticipantes");
            DropTable("dbo.ExperienciaLaborals");
            DropTable("dbo.Cursoes");
            DropTable("dbo.CandidatoSeguidorCandidatoes");
            DropTable("dbo.CandidatoHabilidads");
            DropTable("dbo.Habilidads");
            DropTable("dbo.Usuarios");
            DropTable("dbo.MiembroGrupoes");
            DropTable("dbo.CandidatoGrupoes");
            DropTable("dbo.Grupoes");
            DropTable("dbo.Comentarios");
            DropTable("dbo.Publicacions");
            DropTable("dbo.EmpresaSeguidorEmpresas");
            DropTable("dbo.CandidatoSeguidorEmpresas");
            DropTable("dbo.EmpresaSeguidorCandidatoes");
            DropTable("dbo.CandidatoEmpresaConexiones");
            DropTable("dbo.Empresas");
            DropTable("dbo.OfertaLaborals");
            DropTable("dbo.CandidatoOfertaLaborals");
            DropTable("dbo.Candidatos");
            DropTable("dbo.CandidatoCandidatoConexiones");
        }
    }
}
