namespace AbpCoreEf6Sample.EntityFramework.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly AbpCoreEf6SampleDbContext _context;

        public InitialHostDbBuilder(AbpCoreEf6SampleDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
