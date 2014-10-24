namespace AbpjTable.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        BirthCityId = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.BirthCityId, cascadeDelete: true)
                .Index(t => t.BirthCityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "BirthCityId", "dbo.Cities");
            DropIndex("dbo.People", new[] { "BirthCityId" });
            DropTable("dbo.People",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "Abp_SoftDelete", "True" },
                });
            DropTable("dbo.Cities");
        }
    }
}
