namespace SimpleTaskSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StsPeople",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StsTasks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AssignedPersonId = c.Int(),
                        Description = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        State = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StsPeople", t => t.AssignedPersonId)
                .Index(t => t.AssignedPersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StsTasks", "AssignedPersonId", "dbo.StsPeople");
            DropIndex("dbo.StsTasks", new[] { "AssignedPersonId" });
            DropTable("dbo.StsTasks");
            DropTable("dbo.StsPeople");
        }
    }
}
