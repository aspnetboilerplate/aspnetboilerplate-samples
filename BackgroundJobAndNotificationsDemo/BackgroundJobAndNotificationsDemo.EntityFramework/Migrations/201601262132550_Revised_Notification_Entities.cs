namespace BackgroundJobAndNotificationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revised_Notification_Entities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpNotifications", "DataTypeName", c => c.String());
            AddColumn("dbo.AbpNotifications", "EntityTypeAssemblyQualifiedName", c => c.String(maxLength: 512));
            RenameColumn("dbo.AbpNotifications", "EntityType", "EntityTypeName");
            RenameColumn("dbo.AbpNotificationSubscriptions", "EntityType", "EntityTypeName");
        }
        
        public override void Down()
        {
            //not important for this solution.
        }
    }
}
