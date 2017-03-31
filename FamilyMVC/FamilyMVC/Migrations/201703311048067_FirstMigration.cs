namespace FamilyMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MembersRelationships",
                c => new
                    {
                        MembersID = c.Int(nullable: false),
                        RelativesID = c.Int(nullable: false),
                        ReationshpsID = c.Int(nullable: false),
                        MembersRelationshipsID = c.Int(nullable: false, identity: true),
                        Members_Id = c.Int(),
                        Members_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.MembersRelationshipsID)
                .ForeignKey("dbo.Members", t => t.MembersID, cascadeDelete: true)
                .ForeignKey("dbo.Relationships", t => t.ReationshpsID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.RelativesID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Members_Id)
                .ForeignKey("dbo.Members", t => t.Members_Id1)
                .Index(t => t.MembersID)
                .Index(t => t.RelativesID)
                .Index(t => t.ReationshpsID)
                .Index(t => t.Members_Id)
                .Index(t => t.Members_Id1);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kind = c.String(),
                        InCrown = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MembersRelationships", "Members_Id1", "dbo.Members");
            DropForeignKey("dbo.MembersRelationships", "Members_Id", "dbo.Members");
            DropForeignKey("dbo.MembersRelationships", "RelativesID", "dbo.Members");
            DropForeignKey("dbo.MembersRelationships", "ReationshpsID", "dbo.Relationships");
            DropForeignKey("dbo.MembersRelationships", "MembersID", "dbo.Members");
            DropIndex("dbo.MembersRelationships", new[] { "Members_Id1" });
            DropIndex("dbo.MembersRelationships", new[] { "Members_Id" });
            DropIndex("dbo.MembersRelationships", new[] { "ReationshpsID" });
            DropIndex("dbo.MembersRelationships", new[] { "RelativesID" });
            DropIndex("dbo.MembersRelationships", new[] { "MembersID" });
            DropTable("dbo.Relationships");
            DropTable("dbo.MembersRelationships");
            DropTable("dbo.Members");
        }
    }
}
