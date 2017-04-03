namespace Relations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                "dbo.MemberRelationships",
                c => new
                    {
                        MembersID = c.Int(nullable: false),
                        RelativesID = c.Int(nullable: false),
                        ReationshpsID = c.Int(nullable: false),
                        MembersRelationshipsID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MembersRelationshipsID)
                .ForeignKey("dbo.Members", t => t.MembersID)
                .ForeignKey("dbo.Relationships", t => t.ReationshpsID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.RelativesID)
                .Index(t => t.MembersID)
                .Index(t => t.RelativesID)
                .Index(t => t.ReationshpsID);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kind = c.String(),
                        InCrown = c.Boolean(nullable: false),
                        ReverseRelationshipId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Relationships", t => t.ReverseRelationshipId)
                .Index(t => t.ReverseRelationshipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberRelationships", "RelativesID", "dbo.Members");
            DropForeignKey("dbo.MemberRelationships", "ReationshpsID", "dbo.Relationships");
            DropForeignKey("dbo.Relationships", "ReverseRelationshipId", "dbo.Relationships");
            DropForeignKey("dbo.MemberRelationships", "MembersID", "dbo.Members");
            DropIndex("dbo.Relationships", new[] { "ReverseRelationshipId" });
            DropIndex("dbo.MemberRelationships", new[] { "ReationshpsID" });
            DropIndex("dbo.MemberRelationships", new[] { "RelativesID" });
            DropIndex("dbo.MemberRelationships", new[] { "MembersID" });
            DropTable("dbo.Relationships");
            DropTable("dbo.MemberRelationships");
            DropTable("dbo.Members");
        }
    }
}
