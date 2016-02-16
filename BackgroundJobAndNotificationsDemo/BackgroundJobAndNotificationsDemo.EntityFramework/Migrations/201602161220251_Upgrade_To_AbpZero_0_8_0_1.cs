namespace BackgroundJobAndNotificationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgrade_To_AbpZero_0_8_0_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpNotifications", "ExcludedUserIds", c => c.String());
            AddColumn("dbo.AbpNotifications", "TenantIds", c => c.String());
            AddColumn("dbo.AbpNotificationSubscriptions", "TenantId", c => c.Int());
            CreateIndex("dbo.AbpUserNotifications", new[] { "UserId", "State", "CreationTime" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpUserNotifications", new[] { "UserId", "State", "CreationTime" });
            DropColumn("dbo.AbpNotificationSubscriptions", "TenantId");
            DropColumn("dbo.AbpNotifications", "TenantIds");
            DropColumn("dbo.AbpNotifications", "ExcludedUserIds");
        }
    }
}
