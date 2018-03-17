using Abp.Zero.EntityFrameworkCore;
using Acme.ProjectName.Authorization.Roles;
using Acme.ProjectName.Authorization.Users;
using Acme.ProjectName.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Acme.ProjectName.EntityFrameworkCore
{
    public class ProjectNameDbContext : AbpZeroDbContext<Tenant, Role, User, ProjectNameDbContext>
    {
        /* Define an IDbSet for each entity of the application */
        
        public ProjectNameDbContext(DbContextOptions<ProjectNameDbContext> options)
            : base(options)
        {

        }
    }
}
