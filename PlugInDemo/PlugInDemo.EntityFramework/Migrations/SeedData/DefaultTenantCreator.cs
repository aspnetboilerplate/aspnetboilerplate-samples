using System.Linq;
using PlugInDemo.EntityFramework;
using PlugInDemo.MultiTenancy;

namespace PlugInDemo.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly PlugInDemoDbContext _context;

        public DefaultTenantCreator(PlugInDemoDbContext context)
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
