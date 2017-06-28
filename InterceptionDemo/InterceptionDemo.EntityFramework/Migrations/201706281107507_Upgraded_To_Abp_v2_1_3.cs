namespace InterceptionDemo.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;

    public partial class Upgraded_To_Abp_v2_1_3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AbpSettings", "TenantId", "dbo.AbpTenants");
            DropForeignKey("dbo.AbpUsers", "TenantId", "dbo.AbpTenants");
            DropForeignKey("dbo.AbpRoles", "TenantId", "dbo.AbpTenants");
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });
            DropIndex("dbo.AbpRoles", new[] { "TenantId" });
            DropIndex("dbo.AbpUsers", new[] { "TenantId" });
            DropIndex("dbo.AbpSettings", new[] { "TenantId" });
            CreateTable(
                "dbo.AbpUserClaims",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserClaim_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AbpTenantNotifications",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    TenantId = c.Int(),
                    NotificationName = c.String(nullable: false, maxLength: 96),
                    Data = c.String(),
                    DataTypeName = c.String(maxLength: 512),
                    EntityTypeName = c.String(maxLength: 250),
                    EntityTypeAssemblyQualifiedName = c.String(maxLength: 512),
                    EntityId = c.String(maxLength: 96),
                    Severity = c.Byte(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TenantNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AbpUserAccounts",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    UserLinkId = c.Long(),
                    UserName = c.String(),
                    EmailAddress = c.String(),
                    LastLoginTime = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                    DeleterUserId = c.Long(),
                    DeletionTime = c.DateTime(),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserAccount_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AbpUserLoginAttempts",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    TenancyName = c.String(maxLength: 64),
                    UserId = c.Long(),
                    UserNameOrEmailAddress = c.String(maxLength: 255),
                    ClientIpAddress = c.String(maxLength: 64),
                    ClientName = c.String(maxLength: 128),
                    BrowserInfo = c.String(maxLength: 256),
                    Result = c.Byte(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLoginAttempt_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.UserId, t.TenantId })
                .Index(t => new { t.TenancyName, t.UserNameOrEmailAddress, t.Result });

            AlterTableAnnotations(
                "dbo.AbpFeatures",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 128),
                    Value = c.String(nullable: false, maxLength: 2000),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    EditionId = c.Int(),
                    TenantId = c.Int(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_TenantFeatureSetting_MustHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpNotificationSubscriptions",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    NotificationName = c.String(maxLength: 96),
                    EntityTypeName = c.String(maxLength: 250),
                    EntityTypeAssemblyQualifiedName = c.String(maxLength: 512),
                    EntityId = c.String(maxLength: 96),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_NotificationSubscriptionInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpPermissions",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    Name = c.String(nullable: false, maxLength: 128),
                    IsGranted = c.Boolean(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    RoleId = c.Int(),
                    UserId = c.Long(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_PermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    {
                        "DynamicFilter_RolePermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    {
                        "DynamicFilter_UserPermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpUserLogins",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 256),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_UserLogin_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpUserRoles",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    RoleId = c.Int(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_UserRole_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpSettings",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(),
                    Name = c.String(nullable: false, maxLength: 256),
                    Value = c.String(maxLength: 2000),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_Setting_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpUserNotifications",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    TenantNotificationId = c.Guid(nullable: false),
                    State = c.Int(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_UserNotificationInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });

            AddColumn("dbo.AbpLanguages", "IsDisabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpPermissions", "TenantId", c => c.Int());
            AddColumn("dbo.AbpUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.AbpUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.AbpUsers", "IsLockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AbpUsers", "IsPhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpUsers", "SecurityStamp", c => c.String());
            AddColumn("dbo.AbpUsers", "IsTwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AbpUserLogins", "TenantId", c => c.Int());
            AddColumn("dbo.AbpUserRoles", "TenantId", c => c.Int());
            AddColumn("dbo.AbpTenants", "ConnectionString", c => c.String(maxLength: 1024));
            AddColumn("dbo.AbpUserNotifications", "TenantId", c => c.Int());
            AddColumn("dbo.AbpUserNotifications", "TenantNotificationId", c => c.Guid(nullable: false));
            AlterColumn("dbo.AbpNotifications", "NotificationName", c => c.String(nullable: false, maxLength: 96));
            AlterColumn("dbo.AbpNotifications", "EntityTypeName", c => c.String(maxLength: 250));
            AlterColumn("dbo.AbpNotifications", "EntityId", c => c.String(maxLength: 96));
            AlterColumn("dbo.AbpNotificationSubscriptions", "NotificationName", c => c.String(maxLength: 96));
            AlterColumn("dbo.AbpNotificationSubscriptions", "EntityTypeName", c => c.String(maxLength: 250));
            AlterColumn("dbo.AbpNotificationSubscriptions", "EntityId", c => c.String(maxLength: 96));
            DropIndex("dbo.AbpOrganizationUnits", "IX_TenantId_Code");
            AlterColumn("dbo.AbpOrganizationUnits", "Code", c => c.String(nullable: false, maxLength: 95));
            CreateIndex("dbo.AbpOrganizationUnits", new[] { "TenantId", "Code" });
            AlterColumn("dbo.AbpUsers", "EmailConfirmationCode", c => c.String(maxLength: 328));
            CreateIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });
            DropColumn("dbo.AbpUserNotifications", "NotificationId");
        }

        public override void Down()
        {
            AddColumn("dbo.AbpUserNotifications", "NotificationId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "UserId", "TenantId" });
            DropIndex("dbo.AbpUserClaims", new[] { "UserId" });
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });
            AlterColumn("dbo.AbpUsers", "EmailConfirmationCode", c => c.String(maxLength: 128));
            AlterColumn("dbo.AbpOrganizationUnits", "Code", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AbpNotificationSubscriptions", "EntityId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AbpNotificationSubscriptions", "EntityTypeName", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpNotificationSubscriptions", "NotificationName", c => c.String(maxLength: 128));
            AlterColumn("dbo.AbpNotifications", "EntityId", c => c.String(maxLength: 128));
            AlterColumn("dbo.AbpNotifications", "EntityTypeName", c => c.String(maxLength: 256));
            AlterColumn("dbo.AbpNotifications", "NotificationName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.AbpUserNotifications", "TenantNotificationId");
            DropColumn("dbo.AbpUserNotifications", "TenantId");
            DropColumn("dbo.AbpTenants", "ConnectionString");
            DropColumn("dbo.AbpUserRoles", "TenantId");
            DropColumn("dbo.AbpUserLogins", "TenantId");
            DropColumn("dbo.AbpUsers", "IsTwoFactorEnabled");
            DropColumn("dbo.AbpUsers", "SecurityStamp");
            DropColumn("dbo.AbpUsers", "IsPhoneNumberConfirmed");
            DropColumn("dbo.AbpUsers", "PhoneNumber");
            DropColumn("dbo.AbpUsers", "IsLockoutEnabled");
            DropColumn("dbo.AbpUsers", "AccessFailedCount");
            DropColumn("dbo.AbpUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AbpPermissions", "TenantId");
            DropColumn("dbo.AbpLanguages", "IsDisabled");
            AlterTableAnnotations(
                "dbo.AbpUserNotifications",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    TenantNotificationId = c.Guid(nullable: false),
                    State = c.Int(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_UserNotificationInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpSettings",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(),
                    Name = c.String(nullable: false, maxLength: 256),
                    Value = c.String(maxLength: 2000),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_Setting_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpUserRoles",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    RoleId = c.Int(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_UserRole_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpUserLogins",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 256),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_UserLogin_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpPermissions",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    TenantId = c.Int(),
                    Name = c.String(nullable: false, maxLength: 128),
                    IsGranted = c.Boolean(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    RoleId = c.Int(),
                    UserId = c.Long(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_PermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    {
                        "DynamicFilter_RolePermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    {
                        "DynamicFilter_UserPermissionSetting_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpNotificationSubscriptions",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    TenantId = c.Int(),
                    UserId = c.Long(nullable: false),
                    NotificationName = c.String(maxLength: 96),
                    EntityTypeName = c.String(maxLength: 250),
                    EntityTypeAssemblyQualifiedName = c.String(maxLength: 512),
                    EntityId = c.String(maxLength: 96),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_NotificationSubscriptionInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });

            AlterTableAnnotations(
                "dbo.AbpFeatures",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 128),
                    Value = c.String(nullable: false, maxLength: 2000),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                    EditionId = c.Int(),
                    TenantId = c.Int(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    {
                        "DynamicFilter_TenantFeatureSetting_MustHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });

            DropTable("dbo.AbpUserLoginAttempts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserLoginAttempt_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpUserAccounts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserAccount_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpTenantNotifications",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TenantNotificationInfo_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpUserClaims",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_UserClaim_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            CreateIndex("dbo.AbpSettings", "TenantId");
            CreateIndex("dbo.AbpUsers", "TenantId");
            CreateIndex("dbo.AbpRoles", "TenantId");
            CreateIndex("dbo.AbpNotificationSubscriptions", new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });
            AddForeignKey("dbo.AbpRoles", "TenantId", "dbo.AbpTenants", "Id");
            AddForeignKey("dbo.AbpUsers", "TenantId", "dbo.AbpTenants", "Id");
            AddForeignKey("dbo.AbpSettings", "TenantId", "dbo.AbpTenants", "Id");
        }
    }
}
