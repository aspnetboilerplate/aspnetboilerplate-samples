using System.Collections.Generic;

namespace IdentityServerDemo.SSO.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
