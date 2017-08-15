using AbpPerformanceTestApp.EntityFrameworkCore;

namespace AbpPerformanceTestApp.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly AbpPerformanceTestAppDbContext _context;

        public TestDataBuilder(AbpPerformanceTestAppDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}