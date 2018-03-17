using System.Collections.Generic;

namespace Volo.PostgreSqlDemo.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
