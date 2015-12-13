using System.Data.Entity;
using Abp.EntityFramework;

namespace MultipleDbContextDemo.EntityFramework
{
    public class MySecondDbContext : AbpDbContext
    {
        public virtual IDbSet<Course> Courses { get; set; }

        public MySecondDbContext()
            : base("Second")
        {
            
        }
    }
}
