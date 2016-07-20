using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Collections;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Runtime.Session;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using EntityFramework.DynamicFilters;
using OrganizationUnitsDemo.EntityFramework;
using OrganizationUnitsDemo.Migrations.SeedData;
using OrganizationUnitsDemo.MultiTenancy;
using OrganizationUnitsDemo.Users;

namespace OrganizationUnitsDemo.Tests
{
    public abstract class OrganizationUnitsDemoTestBase : AbpIntegratedTestBase<OrganizationUnitsDemoTestModule>
    {
        protected OrganizationUnitsDemoTestBase()
        {
            //Seed initial data
            UsingDbContext(context => new InitialDataBuilder(context).Build());

            LoginAsDefaultTenantAdmin();
        }

        protected override void PreInitialize()
        {
            base.PreInitialize();

            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );
        }

        public void UsingDbContext(Action<OrganizationUnitsDemoDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<OrganizationUnitsDemoDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<OrganizationUnitsDemoDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<OrganizationUnitsDemoDbContext>())
            {
                context.DisableAllFilters();
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected void LoginAsHostAdmin()
        {
            LoginAsHost(User.AdminUserName);
        }

        protected void LoginAsDefaultTenantAdmin()
        {
            LoginAsTenant(Tenant.DefaultTenantName, User.AdminUserName);
        }

        protected void LoginAsHost(string userName)
        {
            Resolve<IMultiTenancyConfig>().IsEnabled = true;

            AbpSession.TenantId = null;

            var user = UsingDbContext(context => context.Users.FirstOrDefault(u => u.TenantId == AbpSession.TenantId && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for host.");
            }

            AbpSession.UserId = user.Id;
        }

        protected void LoginAsTenant(string tenancyName, string userName)
        {
            var tenant = UsingDbContext(context => context.Tenants.FirstOrDefault(t => t.TenancyName == tenancyName));
            if (tenant == null)
            {
                throw new Exception("There is no tenant: " + tenancyName);
            }

            AbpSession.TenantId = tenant.Id;

            var user = UsingDbContext(context => context.Users.FirstOrDefault(u => u.TenantId == AbpSession.TenantId && u.UserName == userName));
            if (user == null)
            {
                throw new Exception("There is no user: " + userName + " for tenant: " + tenancyName);
            }

            AbpSession.UserId = user.Id;
        }

        /// <summary>
        /// Gets current user if <see cref="IAbpSession.UserId"/> is not null.
        /// Throws exception if it's null.
        /// </summary>
        protected async Task<User> GetCurrentUserAsync()
        {
            var userId = AbpSession.GetUserId();
            return await UsingDbContext(context => context.Users.SingleAsync(u => u.Id == userId));
        }

        /// <summary>
        /// Gets current tenant if <see cref="IAbpSession.TenantId"/> is not null.
        /// Throws exception if there is no current tenant.
        /// </summary>
        protected async Task<Tenant> GetCurrentTenantAsync()
        {
            var tenantId = AbpSession.GetTenantId();
            return await UsingDbContext(context => context.Tenants.SingleAsync(t => t.Id == tenantId));
        }
    }
}