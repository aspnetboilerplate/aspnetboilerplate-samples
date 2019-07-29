using Abp.Application.Services;

namespace AbpWcfDemo
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class WcfAppServiceBase : ApplicationService
    {
        protected WcfAppServiceBase()
        {
            LocalizationSourceName = WcfConsts.LocalizationSourceName;
        }
    }
}