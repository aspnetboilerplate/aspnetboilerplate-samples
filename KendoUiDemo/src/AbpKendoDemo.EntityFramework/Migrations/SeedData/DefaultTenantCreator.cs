using System.Linq;
using AbpKendoDemo.EntityFramework;
using AbpKendoDemo.MultiTenancy;

namespace AbpKendoDemo.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly AbpKendoDemoDbContext _context;

        public DefaultTenantCreator(AbpKendoDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
