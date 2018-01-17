namespace DataCollectorApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClasseEnquete : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.__MigrationHistory",
            //    c => new
            //        {
            //            MigrationId = c.String(nullable: false, maxLength: 150),
            //            ContextKey = c.String(nullable: false, maxLength: 300),
            //            Model = c.Binary(nullable: false),
            //            ProductVersion = c.String(nullable: false, maxLength: 32),
            //        })
            //    .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.CategorieIndicateur",
                c => new
                    {
                        caID = c.Short(nullable: false),
                        caNom = c.String(nullable: false, maxLength: 50, unicode: false),
                        caCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        caCreationDate = c.DateTime(nullable: false),
                        caModificationUser = c.String(maxLength: 50, unicode: false),
                        caModificationDate = c.DateTime(),
                        caRowversion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        caStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.caID);
            
            CreateTable(
                "dbo.CibleEnquete",
                c => new
                    {
                        ceID = c.Short(nullable: false),
                        ceLibelle = c.String(maxLength: 50, unicode: false),
                        ceCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        ceCreationDate = c.DateTime(),
                        ceModificationUser = c.String(maxLength: 50, unicode: false),
                        ceModificationDate = c.DateTime(),
                        ceRowversion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        ceStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ceID);
            
            CreateTable(
                "dbo.CibleEnquetes",
                c => new
                    {
                        ID = c.Short(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Enquetes",
                c => new
                    {
                        EnqueteID = c.Long(nullable: false, identity: true),
                        Titre = c.String(),
                        Campagne = c.String(),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        EstDesactive = c.Boolean(nullable: false),
                        CreationUtilisateur = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationUtilisateur = c.String(),
                        ModificationDate = c.DateTime(nullable: false),
                        RowVersion = c.Binary(),
                        Cible_ID = c.Short(),
                    })
                .PrimaryKey(t => t.EnqueteID)
                .ForeignKey("dbo.CibleEnquetes", t => t.Cible_ID)
                .Index(t => t.Cible_ID);
            
            CreateTable(
                "dbo.Enquete",
                c => new
                    {
                        enID = c.Long(nullable: false, identity: true),
                        enTitre = c.String(maxLength: 100, unicode: false),
                        enCampagne = c.String(nullable: false, maxLength: 9, fixedLength: true, unicode: false),
                        enDateDebut = c.DateTime(nullable: false),
                        enDateFin = c.DateTime(nullable: false),
                        enCibleEnqueteID = c.Short(nullable: false),
                        enCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        enCreationDate = c.DateTime(nullable: false),
                        enModificationDate = c.DateTime(),
                        enModificationUser = c.String(maxLength: 50, unicode: false),
                        enRowversion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        enStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.enID);
            
            CreateTable(
                "dbo.FonctionCalcul",
                c => new
                    {
                        fcID = c.Short(nullable: false),
                        fcNom = c.String(nullable: false, maxLength: 50, unicode: false),
                        fcCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        fcCreationDate = c.DateTime(nullable: false),
                        fcModificationUser = c.String(maxLength: 50, unicode: false),
                        fcModificationDate = c.DateTime(),
                        fcRowversion = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        fcStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.fcID);
            
            CreateTable(
                "dbo.Indicateur",
                c => new
                    {
                        inID = c.Int(nullable: false),
                        inNom = c.String(nullable: false, maxLength: 50, unicode: false),
                        inEnqueteID = c.Long(nullable: false),
                        inQuestionID = c.Long(nullable: false),
                        inFonctionCalculD = c.Short(nullable: false),
                        inTypeRegroupementID = c.Short(nullable: false),
                        inRepresentationDonneeID = c.Short(nullable: false),
                        inCategorieIndicateurID = c.Short(nullable: false),
                        inCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        inCreationDate = c.DateTime(nullable: false),
                        inModificationUser = c.String(maxLength: 50, unicode: false),
                        inModificationDate = c.DateTime(),
                        inRowversion = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        inStatut = c.Boolean(),
                    })
                .PrimaryKey(t => t.inID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        quID = c.Long(nullable: false),
                        quIntitule = c.String(nullable: false, maxLength: 500, unicode: false),
                        quCourteDescription = c.String(nullable: false, maxLength: 200, unicode: false),
                        quTypeReponseID = c.Short(nullable: false),
                        quEnqueteID = c.Long(nullable: false),
                        quCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        quCreationDate = c.DateTime(),
                        quModificationUser = c.String(maxLength: 50, unicode: false),
                        quModificationDate = c.DateTime(),
                        quRowversion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        quStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.quID);
            
            CreateTable(
                "dbo.ReponseEnquete",
                c => new
                    {
                        reID = c.Guid(nullable: false),
                        reEntiteID = c.Guid(nullable: false),
                        reEnqueteID = c.Long(nullable: false),
                        reCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        reCreationDate = c.DateTime(nullable: false),
                        reModificationUser = c.String(maxLength: 50, unicode: false),
                        reModificationDate = c.DateTime(),
                        reRowversion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        reStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.reID);
            
            CreateTable(
                "dbo.ReponseEnqueteDetail",
                c => new
                    {
                        rdID = c.Guid(nullable: false),
                        rdReponseEnqueteID = c.Long(nullable: false),
                        rdQuestionID = c.Long(nullable: false),
                        rdValeurReponse = c.String(nullable: false, maxLength: 100, unicode: false),
                        rdReponseTypeID = c.Int(nullable: false),
                        rdIsValid = c.Boolean(nullable: false),
                        rdCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        rdCreationDate = c.DateTime(nullable: false),
                        rdModificationUser = c.String(maxLength: 50, unicode: false),
                        rdModificationDate = c.DateTime(),
                        rdRowversion = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        rdStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.rdID);
            
            CreateTable(
                "dbo.ReponsePossible",
                c => new
                    {
                        rpID = c.Int(nullable: false),
                        rpLibelle = c.String(maxLength: 50, unicode: false),
                        rpCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        rpCreationDate = c.DateTime(nullable: false),
                        rpModificationUser = c.String(maxLength: 50, unicode: false),
                        rpModificationDate = c.DateTime(),
                        rpRowversion = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        rpStatut = c.Boolean(),
                    })
                .PrimaryKey(t => t.rpID);
            
            CreateTable(
                "dbo.ReponseType",
                c => new
                    {
                        trID = c.Int(nullable: false),
                        trLibelle = c.String(maxLength: 100, unicode: false),
                        trCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        trCreationDate = c.DateTime(nullable: false),
                        trModificationUser = c.String(maxLength: 50, unicode: false),
                        trModificationDate = c.DateTime(),
                        trRowversion = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        trStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.trID);
            
            CreateTable(
                "dbo.RepresentationDonnees",
                c => new
                    {
                        reID = c.Short(nullable: false),
                        reNom = c.String(nullable: false, maxLength: 50, unicode: false),
                        reCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        reCreationDate = c.DateTime(),
                        reModificationUser = c.String(maxLength: 50, unicode: false),
                        reModificationDate = c.DateTime(),
                        reRowversion = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        reStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.reID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.TypeRegroupement",
                c => new
                    {
                        rgID = c.Short(nullable: false),
                        rgNom = c.String(nullable: false, maxLength: 50, unicode: false),
                        rgCreationUser = c.String(nullable: false, maxLength: 50, unicode: false),
                        rgCreationDate = c.DateTime(nullable: false),
                        rgModificationUser = c.String(maxLength: 50, unicode: false),
                        rgModificationDate = c.DateTime(),
                        rgRowversion = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        rgStatut = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.rgID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enquetes", "Cible_ID", "dbo.CibleEnquetes");
            DropIndex("dbo.Enquetes", new[] { "Cible_ID" });
            DropTable("dbo.TypeRegroupement");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.RepresentationDonnees");
            DropTable("dbo.ReponseType");
            DropTable("dbo.ReponsePossible");
            DropTable("dbo.ReponseEnqueteDetail");
            DropTable("dbo.ReponseEnquete");
            DropTable("dbo.Question");
            DropTable("dbo.Indicateur");
            DropTable("dbo.FonctionCalcul");
            DropTable("dbo.Enquete");
            DropTable("dbo.Enquetes");
            DropTable("dbo.CibleEnquetes");
            DropTable("dbo.CibleEnquete");
            DropTable("dbo.CategorieIndicateur");
            DropTable("dbo.__MigrationHistory");
        }
    }
}
