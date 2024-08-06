using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultipleDbContextEfCoreDemo.Courses;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    // 2. DbContext
    public class MultipleDbContextEfCoreDemoSecondDbContext : AbpDbContext
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Course> Courses { get; set; }

        public MultipleDbContextEfCoreDemoSecondDbContext(DbContextOptions<MultipleDbContextEfCoreDemoSecondDbContext> options)
            : base(options)
        {

        }
    }
}
