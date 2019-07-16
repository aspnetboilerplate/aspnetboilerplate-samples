using Hotel.EntityFrameworkCore.Seed.Tenants;

namespace Hotel.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly HotelDbContext _context;

        public InitialHostDbBuilder(HotelDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            new DefaultHotelBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
