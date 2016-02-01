namespace BackgroundJobAndNotificationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_2016020101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpNotificationSubscriptions", "EntityTypeAssemblyQualifiedName", c => c.String(maxLength: 512));
            AlterColumn("dbo.AbpNotifications", "Data", c => c.String());
            AlterColumn("dbo.AbpNotifications", "DataTypeName", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpNotifications", "DataTypeName", c => c.String());
            AlterColumn("dbo.AbpNotifications", "Data", c => c.String(nullable: false));
            DropColumn("dbo.AbpNotificationSubscriptions", "EntityTypeAssemblyQualifiedName");
        }
    }
}
