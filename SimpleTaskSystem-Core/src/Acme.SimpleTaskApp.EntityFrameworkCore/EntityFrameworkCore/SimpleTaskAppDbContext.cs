using Abp.EntityFrameworkCore;
using Acme.SimpleTaskApp.People;
using Acme.SimpleTaskApp.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Acme.SimpleTaskApp.EntityFrameworkCore
{
    public class SimpleTaskAppDbContext : AbpDbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public SimpleTaskAppDbContext(DbContextOptions<SimpleTaskAppDbContext> options) 
            : base(options)
        {

        }
    }
}
