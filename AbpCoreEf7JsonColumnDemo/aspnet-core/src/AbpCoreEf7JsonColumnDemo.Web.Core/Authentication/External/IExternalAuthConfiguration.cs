using System.Collections.Generic;

namespace AbpCoreEf7JsonColumnDemo.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
