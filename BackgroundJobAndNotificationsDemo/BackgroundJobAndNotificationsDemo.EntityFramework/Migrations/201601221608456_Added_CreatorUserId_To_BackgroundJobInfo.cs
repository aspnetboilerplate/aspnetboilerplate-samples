namespace BackgroundJobAndNotificationsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_CreatorUserId_To_BackgroundJobInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpBackgroundJobs", "CreatorUserId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpBackgroundJobs", "CreatorUserId");
        }
    }
}
