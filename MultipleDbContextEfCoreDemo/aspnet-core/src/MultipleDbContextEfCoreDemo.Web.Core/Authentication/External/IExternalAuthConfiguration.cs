using System.Collections.Generic;

namespace MultipleDbContextEfCoreDemo.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
