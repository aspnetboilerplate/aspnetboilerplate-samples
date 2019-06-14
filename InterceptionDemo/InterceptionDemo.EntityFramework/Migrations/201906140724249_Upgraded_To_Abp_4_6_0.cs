namespace InterceptionDemo.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_Abp_4_6_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpEntityChanges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChangeTime = c.DateTime(nullable: false),
                        ChangeType = c.Byte(nullable: false),
                        EntityChangeSetId = c.Long(nullable: false),
                        EntityId = c.String(maxLength: 48),
                        EntityTypeFullName = c.String(maxLength: 192),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpEntityChangeSets", t => t.EntityChangeSetId, cascadeDelete: true)
                .Index(t => t.EntityChangeSetId)
                .Index(t => new { t.EntityTypeFullName, t.EntityId })
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpEntityPropertyChanges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EntityChangeId = c.Long(nullable: false),
                        NewValue = c.String(maxLength: 512),
                        OriginalValue = c.String(maxLength: 512),
                        PropertyName = c.String(maxLength: 96),
                        PropertyTypeFullName = c.String(maxLength: 192),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityPropertyChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpEntityChanges", t => t.EntityChangeId, cascadeDelete: true)
                .Index(t => t.EntityChangeId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpEntityChangeSets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BrowserInfo = c.String(maxLength: 512),
                        ClientIpAddress = c.String(maxLength: 64),
                        ClientName = c.String(maxLength: 128),
                        CreationTime = c.DateTime(nullable: false),
                        ExtensionData = c.String(),
                        ImpersonatorTenantId = c.Int(),
                        ImpersonatorUserId = c.Long(),
                        Reason = c.String(maxLength: 256),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChangeSet_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CreationTime, name: "IX_TenantId_CreationTime")
                .Index(t => new { t.TenantId, t.Reason })
                .Index(t => t.TenantId)
                .Index(t => t.UserId, name: "IX_TenantId_UserId");
            
            CreateTable(
                "dbo.AbpOrganizationUnitRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        RoleId = c.Int(nullable: false),
                        OrganizationUnitId = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnitRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
            
            AddColumn("dbo.AbpAuditLogs", "ReturnValue", c => c.String());
            AddColumn("dbo.AbpRoles", "NormalizedName", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.AbpUsers", "NormalizedUserName", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.AbpUsers", "NormalizedEmailAddress", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AbpAuditLogs", "BrowserInfo", c => c.String(maxLength: 512));
            AlterColumn("dbo.AbpUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AbpUsers", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.AbpUsers", "PhoneNumber", c => c.String(maxLength: 32));
            AlterColumn("dbo.AbpUsers", "SecurityStamp", c => c.String(maxLength: 128));
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpUserLoginAttempts", "BrowserInfo", c => c.String(maxLength: 512));
            CreateIndex("dbo.AbpAuditLogs", "TenantId");
            CreateIndex("dbo.AbpFeatures", "TenantId");
            CreateIndex("dbo.AbpEditions", "IsDeleted");
            CreateIndex("dbo.AbpLanguages", "TenantId");
            CreateIndex("dbo.AbpLanguages", "IsDeleted");
            CreateIndex("dbo.AbpLanguageTexts", "TenantId");
            CreateIndex("dbo.AbpNotificationSubscriptions", "TenantId");
            CreateIndex("dbo.AbpOrganizationUnits", "TenantId");
            CreateIndex("dbo.AbpOrganizationUnits", "IsDeleted");
            CreateIndex("dbo.AbpPermissions", "TenantId");
            CreateIndex("dbo.AbpRoles", "TenantId");
            CreateIndex("dbo.AbpRoles", "IsDeleted");
            CreateIndex("dbo.AbpUsers", "TenantId");
            CreateIndex("dbo.AbpUsers", "IsDeleted");
            CreateIndex("dbo.AbpUserClaims", "TenantId");
            CreateIndex("dbo.AbpUserLogins", "TenantId");
            CreateIndex("dbo.AbpUserRoles", "TenantId");
            CreateIndex("dbo.AbpSettings", "TenantId");
            CreateIndex("dbo.AbpTenantNotifications", "TenantId");
            CreateIndex("dbo.AbpTenants", "IsDeleted");
            CreateIndex("dbo.AbpUserAccounts", "IsDeleted");
            CreateIndex("dbo.AbpUserLoginAttempts", "TenantId");
            CreateIndex("dbo.AbpUserNotifications", "TenantId");
            CreateIndex("dbo.AbpUserOrganizationUnits", "TenantId");
            CreateIndex("dbo.AbpUserOrganizationUnits", "IsDeleted");
            DropColumn("dbo.AbpUsers", "LastLoginTime");
            DropColumn("dbo.AbpUserAccounts", "LastLoginTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AbpUserAccounts", "LastLoginTime", c => c.DateTime());
            AddColumn("dbo.AbpUsers", "LastLoginTime", c => c.DateTime());
            DropForeignKey("dbo.AbpEntityChanges", "EntityChangeSetId", "dbo.AbpEntityChangeSets");
            DropForeignKey("dbo.AbpEntityPropertyChanges", "EntityChangeId", "dbo.AbpEntityChanges");
            DropIndex("dbo.AbpUserOrganizationUnits", new[] { "IsDeleted" });
            DropIndex("dbo.AbpUserOrganizationUnits", new[] { "TenantId" });
            DropIndex("dbo.AbpUserNotifications", new[] { "TenantId" });
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenantId" });
            DropIndex("dbo.AbpUserAccounts", new[] { "IsDeleted" });
            DropIndex("dbo.AbpTenants", new[] { "IsDeleted" });
            DropIndex("dbo.AbpTenantNotifications", new[] { "TenantId" });
            DropIndex("dbo.AbpSettings", new[] { "TenantId" });
            DropIndex("dbo.AbpUserRoles", new[] { "TenantId" });
            DropIndex("dbo.AbpUserLogins", new[] { "TenantId" });
            DropIndex("dbo.AbpUserClaims", new[] { "TenantId" });
            DropIndex("dbo.AbpUsers", new[] { "IsDeleted" });
            DropIndex("dbo.AbpUsers", new[] { "TenantId" });
            DropIndex("dbo.AbpRoles", new[] { "IsDeleted" });
            DropIndex("dbo.AbpRoles", new[] { "TenantId" });
            DropIndex("dbo.AbpPermissions", new[] { "TenantId" });
            DropIndex("dbo.AbpOrganizationUnits", new[] { "IsDeleted" });
            DropIndex("dbo.AbpOrganizationUnits", new[] { "TenantId" });
            DropIndex("dbo.AbpOrganizationUnitRoles", new[] { "TenantId" });
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "TenantId" });
            DropIndex("dbo.AbpLanguageTexts", new[] { "TenantId" });
            DropIndex("dbo.AbpLanguages", new[] { "IsDeleted" });
            DropIndex("dbo.AbpLanguages", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityChangeSets", "IX_TenantId_UserId");
            DropIndex("dbo.AbpEntityChangeSets", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityChangeSets", new[] { "TenantId", "Reason" });
            DropIndex("dbo.AbpEntityChangeSets", "IX_TenantId_CreationTime");
            DropIndex("dbo.AbpEntityPropertyChanges", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityPropertyChanges", new[] { "EntityChangeId" });
            DropIndex("dbo.AbpEntityChanges", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityChanges", new[] { "EntityTypeFullName", "EntityId" });
            DropIndex("dbo.AbpEntityChanges", new[] { "EntityChangeSetId" });
            DropIndex("dbo.AbpEditions", new[] { "IsDeleted" });
            DropIndex("dbo.AbpFeatures", new[] { "TenantId" });
            DropIndex("dbo.AbpAuditLogs", new[] { "TenantId" });
            AlterColumn("dbo.AbpUserLoginAttempts", "BrowserInfo", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String(maxLength: 32));
            AlterColumn("dbo.AbpUsers", "SecurityStamp", c => c.String());
            AlterColumn("dbo.AbpUsers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.AbpUsers", "Name", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.AbpUsers", "UserName", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.AbpAuditLogs", "BrowserInfo", c => c.String(maxLength: 256));
            DropColumn("dbo.AbpUsers", "NormalizedEmailAddress");
            DropColumn("dbo.AbpUsers", "NormalizedUserName");
            DropColumn("dbo.AbpRoles", "NormalizedName");
            DropColumn("dbo.AbpAuditLogs", "ReturnValue");
            DropTable("dbo.AbpOrganizationUnitRoles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnitRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityChangeSets",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChangeSet_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityPropertyChanges",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityPropertyChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityChanges",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
