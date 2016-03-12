namespace RestoRapido.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CAlertes",
                c => new
                    {
                        AlerteID = c.Int(nullable: false, identity: true),
                        UtilisateurID = c.Int(nullable: false),
                        CTableID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlerteID);
            
            CreateTable(
                "dbo.CCmdRepas",
                c => new
                    {
                        mCmdRepID = c.Int(nullable: false, identity: true),
                        mNbRep = c.Int(nullable: false),
                        mCommentaire = c.String(),
                        mEtoiles = c.Int(nullable: false),
                        m_iRepasId = c.Int(nullable: false),
                        mCmdID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.mCmdRepID)
                .ForeignKey("dbo.CCommandes", t => t.mCmdID)
                .ForeignKey("dbo.CRepas", t => t.m_iRepasId)
                .Index(t => t.m_iRepasId)
                .Index(t => t.mCmdID);
            
            CreateTable(
                "dbo.CCommandes",
                c => new
                    {
                        mCmdID = c.Int(nullable: false, identity: true),
                        mCmdStatusCommande = c.Int(nullable: false),
                        UtilisateurID = c.Int(nullable: false),
                        CRestoID = c.Int(nullable: false),
                        CTableID = c.Int(nullable: false),
                        mCmdCommentCommandes = c.String(),
                        mCmdPrixAvantTaxes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mCmdPrixTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        mCmdDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.mCmdID)
                .ForeignKey("dbo.CRestoes", t => t.CRestoID)
                .ForeignKey("dbo.CTables", t => t.CTableID)
                .ForeignKey("dbo.Utilisateurs", t => t.UtilisateurID)
                .Index(t => t.UtilisateurID)
                .Index(t => t.CRestoID)
                .Index(t => t.CTableID);
            
            CreateTable(
                "dbo.CRestoes",
                c => new
                    {
                        CRestoID = c.Int(nullable: false, identity: true),
                        resNom = c.String(),
                        resPostal = c.String(maxLength: 7),
                        resRue = c.String(),
                        resNoCiv = c.String(),
                    })
                .PrimaryKey(t => t.CRestoID);
            
            CreateTable(
                "dbo.CTables",
                c => new
                    {
                        CTableID = c.Int(nullable: false, identity: true),
                        i_TableNum = c.Int(nullable: false),
                        str_TableCodeQR = c.String(),
                        CRestoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CTableID)
                .ForeignKey("dbo.CRestoes", t => t.CRestoID)
                .Index(t => t.CRestoID);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        UtilisateurID = c.Int(nullable: false, identity: true),
                        UtilisateurMDP = c.String(nullable: false),
                        UtilisateurNomUsager = c.String(nullable: false),
                        UtilisateurNom = c.String(nullable: false),
                        UtilisateurPrenom = c.String(nullable: false),
                        UtilisateurType = c.String(nullable: false),
                        m_boBle = c.Boolean(nullable: false),
                        m_boLait = c.Boolean(nullable: false),
                        m_boOeuf = c.Boolean(nullable: false),
                        m_boArachide = c.Boolean(nullable: false),
                        m_boSoja = c.Boolean(nullable: false),
                        m_boFruitCoque = c.Boolean(nullable: false),
                        m_boPoisson = c.Boolean(nullable: false),
                        m_boSesame = c.Boolean(nullable: false),
                        m_boCrustace = c.Boolean(nullable: false),
                        m_boMollusque = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UtilisateurID);
            
            CreateTable(
                "dbo.CRepas",
                c => new
                    {
                        m_iRepasId = c.Int(nullable: false, identity: true),
                        m_strNom = c.String(nullable: false, maxLength: 50),
                        m_imgImage = c.Binary(),
                        m_iPrix = c.Decimal(nullable: false, precision: 18, scale: 2),
                        m_strDescription = c.String(),
                        m_boBle = c.Boolean(nullable: false),
                        m_boLait = c.Boolean(nullable: false),
                        m_boOeuf = c.Boolean(nullable: false),
                        m_boArachide = c.Boolean(nullable: false),
                        m_boSoja = c.Boolean(nullable: false),
                        m_boFruitCoque = c.Boolean(nullable: false),
                        m_boPoisson = c.Boolean(nullable: false),
                        m_boSesame = c.Boolean(nullable: false),
                        m_boCrustace = c.Boolean(nullable: false),
                        m_boMollusque = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.m_iRepasId);
            
            CreateTable(
                "dbo.CMenus",
                c => new
                    {
                        m_iMenuId = c.Int(nullable: false, identity: true),
                        m_strNom = c.String(nullable: false, maxLength: 50),
                        m_DateDebut = c.DateTime(nullable: false),
                        m_DateFin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.m_iMenuId);
            
            CreateTable(
                "dbo.CRabaisRepas",
                c => new
                    {
                        RabaisID = c.Int(nullable: false, identity: true),
                        m_iRepasId = c.Int(nullable: false),
                        RabaisPrix = c.Int(nullable: false),
                        RabaisDateDebut = c.DateTime(nullable: false),
                        RabaisDateFin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RabaisID)
                .ForeignKey("dbo.CRepas", t => t.m_iRepasId)
                .Index(t => t.m_iRepasId);
            
            CreateTable(
                "dbo.UtilisateurCTables",
                c => new
                    {
                        Utilisateur_UtilisateurID = c.Int(nullable: false),
                        CTable_CTableID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Utilisateur_UtilisateurID, t.CTable_CTableID })
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_UtilisateurID, cascadeDelete: true)
                .ForeignKey("dbo.CTables", t => t.CTable_CTableID, cascadeDelete: true)
                .Index(t => t.Utilisateur_UtilisateurID)
                .Index(t => t.CTable_CTableID);
            
            CreateTable(
                "dbo.CMenuCRepas",
                c => new
                    {
                        CMenu_m_iMenuId = c.Int(nullable: false),
                        CRepas_m_iRepasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CMenu_m_iMenuId, t.CRepas_m_iRepasId })
                .ForeignKey("dbo.CMenus", t => t.CMenu_m_iMenuId, cascadeDelete: true)
                .ForeignKey("dbo.CRepas", t => t.CRepas_m_iRepasId, cascadeDelete: true)
                .Index(t => t.CMenu_m_iMenuId)
                .Index(t => t.CRepas_m_iRepasId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CRabaisRepas", "m_iRepasId", "dbo.CRepas");
            DropForeignKey("dbo.CCmdRepas", "m_iRepasId", "dbo.CRepas");
            DropForeignKey("dbo.CMenuCRepas", "CRepas_m_iRepasId", "dbo.CRepas");
            DropForeignKey("dbo.CMenuCRepas", "CMenu_m_iMenuId", "dbo.CMenus");
            DropForeignKey("dbo.UtilisateurCTables", "CTable_CTableID", "dbo.CTables");
            DropForeignKey("dbo.UtilisateurCTables", "Utilisateur_UtilisateurID", "dbo.Utilisateurs");
            DropForeignKey("dbo.CCommandes", "UtilisateurID", "dbo.Utilisateurs");
            DropForeignKey("dbo.CCommandes", "CTableID", "dbo.CTables");
            DropForeignKey("dbo.CTables", "CRestoID", "dbo.CRestoes");
            DropForeignKey("dbo.CCommandes", "CRestoID", "dbo.CRestoes");
            DropForeignKey("dbo.CCmdRepas", "mCmdID", "dbo.CCommandes");
            DropIndex("dbo.CMenuCRepas", new[] { "CRepas_m_iRepasId" });
            DropIndex("dbo.CMenuCRepas", new[] { "CMenu_m_iMenuId" });
            DropIndex("dbo.UtilisateurCTables", new[] { "CTable_CTableID" });
            DropIndex("dbo.UtilisateurCTables", new[] { "Utilisateur_UtilisateurID" });
            DropIndex("dbo.CRabaisRepas", new[] { "m_iRepasId" });
            DropIndex("dbo.CTables", new[] { "CRestoID" });
            DropIndex("dbo.CCommandes", new[] { "CTableID" });
            DropIndex("dbo.CCommandes", new[] { "CRestoID" });
            DropIndex("dbo.CCommandes", new[] { "UtilisateurID" });
            DropIndex("dbo.CCmdRepas", new[] { "mCmdID" });
            DropIndex("dbo.CCmdRepas", new[] { "m_iRepasId" });
            DropTable("dbo.CMenuCRepas");
            DropTable("dbo.UtilisateurCTables");
            DropTable("dbo.CRabaisRepas");
            DropTable("dbo.CMenus");
            DropTable("dbo.CRepas");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.CTables");
            DropTable("dbo.CRestoes");
            DropTable("dbo.CCommandes");
            DropTable("dbo.CCmdRepas");
            DropTable("dbo.CAlertes");
        }
    }
}
