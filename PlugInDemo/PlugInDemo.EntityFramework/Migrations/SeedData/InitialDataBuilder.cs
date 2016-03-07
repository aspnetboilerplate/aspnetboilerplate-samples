using PlugInDemo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace PlugInDemo.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly PlugInDemoDbContext _context;

        public InitialDataBuilder(PlugInDemoDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
