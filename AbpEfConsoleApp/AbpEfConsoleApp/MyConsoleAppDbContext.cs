using System.Data.Entity;
using Abp.EntityFramework;

namespace AbpEfConsoleApp
{
    //EF DbContext class.
    public class MyConsoleAppDbContext : AbpDbContext
    {
        public virtual IDbSet<User> Users { get; set; }

        public MyConsoleAppDbContext()
            : base("Default")
        {

        }

        public MyConsoleAppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}