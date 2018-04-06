using MultipleDbContextEfCoreDemo.EntityFrameworkCore;

namespace MultipleDbContextEfCoreDemo.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MultipleDbContextEfCoreDemoDbContext _context;

        public TestDataBuilder(MultipleDbContextEfCoreDemoDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}