namespace BackgroundJobAndNotificationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revised_Lengths : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityType", "EntityId", "UserId" });
            AlterColumn("dbo.AbpNotifications", "EntityType", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpNotifications", "EntityId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AbpNotificationSubscriptions", "EntityType", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpNotificationSubscriptions", "EntityId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityType", "EntityId", "UserId" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityType", "EntityId", "UserId" });
            AlterColumn("dbo.AbpNotificationSubscriptions", "EntityId", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpNotificationSubscriptions", "EntityType", c => c.String(maxLength: 512));
            AlterColumn("dbo.AbpNotifications", "EntityId", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpNotifications", "EntityType", c => c.String(maxLength: 512));
            CreateIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityType", "EntityId", "UserId" });
        }
    }
}
