using System.Linq;
using IdentityServer4.EntityFramework.Mappers;

namespace IdentityServerWithEfCoreDemo.EntityFrameworkCore.IdentityServer
{
    public class InitialIdentityServerDbBuilder
    {
        private readonly IdentityServerWithEfCoreDemoDbContext _context;

        public InitialIdentityServerDbBuilder(IdentityServerWithEfCoreDemoDbContext context)
        {
            _context = context;

        }
        public void Create()
        {
            if (!_context.Clients.Any())
            {
                foreach (var client in IdentityServerConfig.GetClients())
                {
                    _context.Clients.Add(client.ToEntity());
                }

                _context.SaveChanges();
            }

            if (!_context.IdentityResources.Any())
            {
                foreach (var resource in IdentityServerConfig.GetIdentityResources())
                {
                    _context.IdentityResources.Add(resource.ToEntity());
                }

                _context.SaveChanges();
            }

            if (!_context.ApiResources.Any())
            {
                foreach (var resource in IdentityServerConfig.GetApiResources())
                {
                    _context.ApiResources.Add(resource.ToEntity());
                }

                _context.SaveChanges();
            }

            _context.SaveChanges();
        }
    }
}
