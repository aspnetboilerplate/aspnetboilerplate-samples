namespace BackgroundJobAndNotificationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_Index_For_Notification : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.AbpNotificationSubscriptions", name: "IX_NotificationName_EntityType_EntityId_UserId", newName: "IX_NotificationName_EntityTypeName_EntityId_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AbpNotificationSubscriptions", name: "IX_NotificationName_EntityTypeName_EntityId_UserId", newName: "IX_NotificationName_EntityType_EntityId_UserId");
        }
    }
}
