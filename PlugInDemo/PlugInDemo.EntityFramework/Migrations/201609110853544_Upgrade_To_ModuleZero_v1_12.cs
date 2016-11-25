namespace PlugInDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgrade_To_ModuleZero_v1_12 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AbpOrganizationUnits", new[] { "TenantId", "Code" });
            AlterColumn("dbo.AbpOrganizationUnits", "Code", c => c.String(nullable: false, maxLength: 95));
            CreateIndex("dbo.AbpOrganizationUnits", new[] { "TenantId", "Code" });
        }

        public override void Down()
        {
            DropIndex("dbo.AbpOrganizationUnits", new[] { "TenantId", "Code" });
            AlterColumn("dbo.AbpOrganizationUnits", "Code", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.AbpOrganizationUnits", new[] { "TenantId", "Code" });
        }
    }
}
