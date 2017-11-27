using IdentityServerDemo.Api.EntityFrameworkCore;

namespace IdentityServerDemo.Api.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly ApiDbContext _context;

        public TestDataBuilder(ApiDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}