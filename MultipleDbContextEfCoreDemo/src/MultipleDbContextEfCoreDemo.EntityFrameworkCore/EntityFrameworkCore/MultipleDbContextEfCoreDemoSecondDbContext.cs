using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    // 2. DbContext
    public class MultipleDbContextEfCoreDemoSecondDbContext : AbpDbContext
    {
        public virtual DbSet<Course> Courses { get; set; }

        public MultipleDbContextEfCoreDemoSecondDbContext(DbContextOptions<MultipleDbContextEfCoreDemoSecondDbContext> options)
            : base(options)
        {

        }
    }
}