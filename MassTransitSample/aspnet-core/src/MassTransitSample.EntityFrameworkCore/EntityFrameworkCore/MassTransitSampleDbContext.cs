using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MassTransitSample.Authorization.Roles;
using MassTransitSample.Authorization.Users;
using MassTransitSample.MultiTenancy;

namespace MassTransitSample.EntityFrameworkCore
{
    public class MassTransitSampleDbContext : AbpZeroDbContext<Tenant, Role, User, MassTransitSampleDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MassTransitSampleDbContext(DbContextOptions<MassTransitSampleDbContext> options)
            : base(options)
        {
        }
    }
}
