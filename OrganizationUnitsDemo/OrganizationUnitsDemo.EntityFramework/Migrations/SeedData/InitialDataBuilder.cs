using OrganizationUnitsDemo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace OrganizationUnitsDemo.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly OrganizationUnitsDemoDbContext _context;

        public InitialDataBuilder(OrganizationUnitsDemoDbContext context)
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
