namespace LikendlnApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    

    public partial class Migracion8Agosto2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Habilidads", "IdCandidato", "dbo.Candidatos");
            DropIndex("dbo.Habilidads", new[] { "IdCandidato" });
            
            CreateTable(
                "dbo.OfertaLaboralHabilidads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdOfertaLaboral = c.Int(nullable: false),
                        IdHabilidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Habilidads", t => t.IdHabilidad, cascadeDelete: true)
                .Index(t => t.IdOfertaLaboral)
                .Index(t => t.IdHabilidad);
            
            DropColumn("dbo.Habilidads", "IdCandidato");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Habilidads", "IdOfertaLaboral", c => c.Int(nullable: false));
            AddColumn("dbo.Habilidads", "IdCandidato", c => c.Int(nullable: false));
            DropForeignKey("dbo.OfertaLaboralHabilidads", "IdHabilidad", "dbo.Habilidads");
            DropIndex("dbo.OfertaLaboralHabilidads", new[] { "IdHabilidad" });
            DropIndex("dbo.OfertaLaboralHabilidads", new[] { "IdOfertaLaboral" });
            DropTable("dbo.OfertaLaboralHabilidads");
            CreateIndex("dbo.Habilidads", "IdOfertaLaboral");
            CreateIndex("dbo.Habilidads", "IdCandidato");
            AddForeignKey("dbo.Habilidads", "IdCandidato", "dbo.Candidatos", "Id");
        }
    }
}
