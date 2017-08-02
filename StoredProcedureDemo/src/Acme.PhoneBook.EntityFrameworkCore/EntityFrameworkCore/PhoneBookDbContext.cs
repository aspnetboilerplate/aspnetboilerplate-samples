using Abp.Zero.EntityFrameworkCore;
using Acme.PhoneBook.Authorization.Roles;
using Acme.PhoneBook.Authorization.Users;
using Acme.PhoneBook.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Acme.PhoneBook.EntityFrameworkCore
{
    public class PhoneBookDbContext : AbpZeroDbContext<Tenant, Role, User, PhoneBookDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
            : base(options)
        {

        }
    }
}
