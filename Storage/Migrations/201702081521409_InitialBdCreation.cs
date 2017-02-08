namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialBdCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accomplishments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TourneyName = c.String(),
                        OppenentId = c.Int(nullable: false),
                        Result = c.String(),
                        Player_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Division = c.String(),
                        Bankroll = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        Loses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Accomplishments", "Player_Id", "dbo.Players");
            DropIndex("dbo.Histories", new[] { "Player_Id" });
            DropIndex("dbo.Accomplishments", new[] { "Player_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.Histories");
            DropTable("dbo.Accomplishments");
        }
    }
}
