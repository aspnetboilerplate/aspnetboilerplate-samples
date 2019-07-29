namespace AbpWcfDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeachEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SoapEvent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        BeachId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeachEvent", t => t.BeachId, cascadeDelete: true)
                .Index(t => t.BeachId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SoapEvent", "BeachId", "dbo.BeachEvent");
            DropIndex("dbo.SoapEvent", new[] { "BeachId" });
            DropTable("dbo.SoapEvent");
            DropTable("dbo.BeachEvent");
        }
    }
}
