using System.Data.Entity;
using Abp.Domain.Repositories.EntityFramework;
using SimpleTaskSystem.People;
using SimpleTaskSystem.Tasks;

namespace SimpleTaskSystem.EntityFramework.Repositories
{
    public class SimpleTaskSystemDbContext : AbpDbContext
    {
        public virtual IDbSet<Person> People { get; set; }

        public virtual IDbSet<Task> Tasks { get; set; }

        public SimpleTaskSystemDbContext(): base("MainDb")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("StsPeople");
            modelBuilder.Entity<Task>().ToTable("StsTasks").HasOptional(t => t.AssignedPerson);
        }
    }
}
