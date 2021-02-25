using System.Collections.Generic;

namespace AbpCoreEf6Sample.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
