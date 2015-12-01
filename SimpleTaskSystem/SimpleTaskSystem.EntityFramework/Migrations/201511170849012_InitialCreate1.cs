namespace SimpleTaskSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StsPeople", "Phone", c => c.String());
            AddColumn("dbo.StsPeople", "Sex", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StsPeople", "Phone");
            DropColumn("dbo.StsPeople", "Sex");
        }
    }
}
