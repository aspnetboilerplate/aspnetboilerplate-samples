using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AbpPerformanceTestApp.EntityFrameworkCore
{
    public class AbpPerformanceTestAppDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public virtual DbSet<Person> Persons { get; set; }

        public AbpPerformanceTestAppDbContext(DbContextOptions<AbpPerformanceTestAppDbContext> options) 
            : base(options)
        {

        }
    }
}
