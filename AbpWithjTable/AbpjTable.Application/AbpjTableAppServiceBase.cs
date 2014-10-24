using Abp.Application.Services;

namespace AbpjTable
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class AbpjTableAppServiceBase : ApplicationService
    {
        protected AbpjTableAppServiceBase()
        {
            LocalizationSourceName = AbpjTableConsts.LocalizationSourceName;
        }
    }
}