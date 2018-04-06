using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MultipleDbContextEfCoreDemo.EntityFrameworkCore
{
    // 1. DbContext
    public class MultipleDbContextEfCoreDemoDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public virtual DbSet<Person> Persons { get; set; }

        public MultipleDbContextEfCoreDemoDbContext(DbContextOptions<MultipleDbContextEfCoreDemoDbContext> options) 
            : base(options)
        {

        }
    }
}
