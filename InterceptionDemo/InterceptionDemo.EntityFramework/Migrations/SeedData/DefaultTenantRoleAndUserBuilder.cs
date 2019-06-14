using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using InterceptionDemo.Authorization;
using InterceptionDemo.Authorization.Roles;
using InterceptionDemo.EntityFramework;
using InterceptionDemo.MultiTenancy;
using InterceptionDemo.Users;
using Microsoft.AspNet.Identity;

namespace InterceptionDemo.Migrations.SeedData
{
    public class DefaultTenantRoleAndUserBuilder
    {
        private readonly InterceptionDemoDbContext _context;

        public DefaultTenantRoleAndUserBuilder(InterceptionDemoDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Admin role for host

            var adminRoleForHost = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == StaticRoleNames.Host.Admin);
            if (adminRoleForHost == null)
            {
                adminRoleForHost = _context.Roles.Add(new Role
                {
                    Name = StaticRoleNames.Host.Admin,
                    NormalizedName = StaticRoleNames.Host.Admin.ToUpperInvariant(),
                    DisplayName = StaticRoleNames.Host.Admin,
                    IsStatic = true
                });
                _context.SaveChanges();

                //Grant all tenant permissions
                var permissions = PermissionFinder
                    .GetAllPermissions(new InterceptionDemoAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Host))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRoleForHost.Id
                        });
                }

                _context.SaveChanges();
            }

            //Admin user for tenancy host

            var adminUserForHost = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == User.AdminUserName);
            if (adminUserForHost == null)
            {
                adminUserForHost = _context.Users.Add(
                    new User
                    {
                        TenantId = null,
                        UserName = User.AdminUserName,
                        NormalizedUserName = User.AdminUserName.ToUpperInvariant(),
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        NormalizedEmailAddress = "admin@aspnetboilerplate.com".ToUpperInvariant(),
                        IsEmailConfirmed = true,
                        Password = new PasswordHasher().HashPassword(User.DefaultPassword)
                    });

                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(null, adminUserForHost.Id, adminRoleForHost.Id));

                _context.SaveChanges();
            }

            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == "Default");
            if (defaultTenant == null)
            {
                defaultTenant = _context.Tenants.Add(new Tenant { TenancyName = "Default", Name = "Default" });
                _context.SaveChanges();
            }

            //Admin role for 'Default' tenant

            var adminRoleForDefaultTenant = _context.Roles.FirstOrDefault(r => r.TenantId == defaultTenant.Id && r.Name == StaticRoleNames.Tenants.Admin);
            if (adminRoleForDefaultTenant == null)
            {
                adminRoleForDefaultTenant = _context.Roles.Add(new Role
                {
                    TenantId = defaultTenant.Id,
                    Name = StaticRoleNames.Tenants.Admin,
                    NormalizedName = StaticRoleNames.Tenants.Admin.ToUpperInvariant(),
                    DisplayName = StaticRoleNames.Tenants.Admin,
                    IsStatic = true
                });
                _context.SaveChanges();

                //Grant all tenant permissions
                var permissions = PermissionFinder
                    .GetAllPermissions(new InterceptionDemoAuthorizationProvider())
                    .Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant))
                    .ToList();

                foreach (var permission in permissions)
                {
                    _context.Permissions.Add(
                        new RolePermissionSetting
                        {
                            Name = permission.Name,
                            IsGranted = true,
                            RoleId = adminRoleForDefaultTenant.Id
                        });
                }

                _context.SaveChanges();
            }

            //Admin for 'Default' tenant

            var adminUserForDefaultTenant = _context.Users.FirstOrDefault(u => u.TenantId == defaultTenant.Id && u.UserName == User.AdminUserName);
            if (adminUserForDefaultTenant == null)
            {
                adminUserForDefaultTenant = _context.Users.Add(
                    new User
                    {
                        TenantId = defaultTenant.Id,
                        UserName = User.AdminUserName,
                        NormalizedUserName = User.AdminUserName.ToUpperInvariant(),
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        NormalizedEmailAddress = "admin@aspnetboilerplate.com".ToUpperInvariant(),
                        IsEmailConfirmed = true,
                        Password = new PasswordHasher().HashPassword(User.DefaultPassword)
                    });
                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(defaultTenant.Id, adminUserForDefaultTenant.Id, adminRoleForDefaultTenant.Id));
                _context.SaveChanges();
            }
        }
    }
}