namespace BackgroundJobAndNotificationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_BackgroundJobInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpBackgroundJobs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobType = c.String(nullable: false, maxLength: 512),
                        JobArgs = c.String(nullable: false),
                        TryCount = c.Short(nullable: false),
                        NextTryTime = c.DateTime(nullable: false),
                        LastTryTime = c.DateTime(),
                        CreationTime = c.DateTime(nullable: false),
                        IsAbandoned = c.Boolean(nullable: false),
                        Priority = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.IsAbandoned, t.NextTryTime });
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpBackgroundJobs", new[] { "IsAbandoned", "NextTryTime" });
            DropTable("dbo.AbpBackgroundJobs");
        }
    }
}
