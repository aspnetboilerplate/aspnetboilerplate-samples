namespace SimpleTaskSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StsPeople", "Sex", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StsPeople", "Sex");
        }
    }
}
