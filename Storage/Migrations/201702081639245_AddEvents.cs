namespace Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Division = c.String(),
                        EventType = c.Int(nullable: false),
                        Finished = c.Boolean(nullable: false),
                        Champ = c.String(),
                        RunnerUp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
