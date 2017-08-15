using Abp.Application.Services;

namespace AbpPerformanceTestApp
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class AbpPerformanceTestAppAppServiceBase : ApplicationService
    {
        protected AbpPerformanceTestAppAppServiceBase()
        {
            LocalizationSourceName = AbpPerformanceTestAppConsts.LocalizationSourceName;
        }
    }
}