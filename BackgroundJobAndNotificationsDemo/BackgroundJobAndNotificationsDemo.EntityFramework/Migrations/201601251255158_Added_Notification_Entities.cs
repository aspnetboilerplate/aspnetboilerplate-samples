namespace BackgroundJobAndNotificationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Notification_Entities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NotificationName = c.String(nullable: false, maxLength: 128),
                        Data = c.String(nullable: false),
                        EntityType = c.String(maxLength: 512),
                        EntityId = c.String(maxLength: 256),
                        Severity = c.Byte(nullable: false),
                        UserIds = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AbpNotificationSubscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Long(nullable: false),
                        NotificationName = c.String(maxLength: 128),
                        EntityType = c.String(maxLength: 512),
                        EntityId = c.String(maxLength: 256),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.NotificationName, t.EntityType, t.EntityId, t.UserId });
            
            CreateTable(
                "dbo.AbpUserNotifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Long(nullable: false),
                        NotificationId = c.Guid(nullable: false),
                        State = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityType", "EntityId", "UserId" });
            DropTable("dbo.AbpUserNotifications");
            DropTable("dbo.AbpNotificationSubscriptions");
            DropTable("dbo.AbpNotifications");
        }
    }
}
