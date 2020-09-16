using System.Collections.Generic;

namespace IdentityServerWithEfCoreDemo.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
