using System.Collections.Generic;
using System.Linq;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace IdentityServerDemo.IdentityServer
{
     public static class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("default-api", "Default (all) API")
                {
                    Description = "AllFunctionalityYouHaveInTheApplication",
                    ApiSecrets= {new Secret("secret") }
                }
            };
        }

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

        public static IEnumerable<Client> GetClients(IConfigurationRoot configuration)
        {
            var clients = new List<Client>();

            foreach (var child in configuration.GetSection("IdentityServer:Clients").GetChildren())
            {
                clients.Add(new Client
                {
                    ClientId = child["ClientId"],
                    ClientName = child["ClientName"],
                    AllowedGrantTypes = child.GetSection("AllowedGrantTypes").GetChildren().Select(c => c.Value).ToArray(),
                    RequireConsent = bool.Parse(child["RequireConsent"] ?? "false"),
                    AllowOfflineAccess = bool.Parse(child["AllowOfflineAccess"] ?? "false"),
                    ClientSecrets = child.GetSection("ClientSecrets").GetChildren().Select(secret => new Secret(secret["Value"].Sha256())).ToArray(),
                    AllowedScopes = child.GetSection("AllowedScopes").GetChildren().Select(c => c.Value).ToArray(),
                    RedirectUris = child.GetSection("RedirectUris").GetChildren().Select(c => c.Value).ToArray(),
                    PostLogoutRedirectUris = child.GetSection("PostLogoutRedirectUris").GetChildren().Select(c => c.Value).ToArray(),
                });
            }

            return clients;
        }
    }
}
