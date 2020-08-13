using System.Collections.Generic;
using System.Linq;
using IdentityServer4.Models;

namespace IdentityServervNextDemo.Web.Startup
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone()
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("default-api-scope")
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("default-api-resource", "Default (all) API")
                {
                    Scopes = { "default-api-scope" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials.Union(GrantTypes.ResourceOwnerPassword).ToList(),
                    AllowedScopes = {"default-api-scope"},
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }
    }
}
