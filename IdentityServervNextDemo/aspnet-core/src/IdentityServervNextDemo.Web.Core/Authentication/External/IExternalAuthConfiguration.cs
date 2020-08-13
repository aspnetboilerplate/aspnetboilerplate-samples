using System.Collections.Generic;

namespace IdentityServervNextDemo.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
