using Abp.Application.Services;

namespace IdentityServerDemo.Api
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class ApiAppServiceBase : ApplicationService
    {
        protected ApiAppServiceBase()
        {
            LocalizationSourceName = ApiConsts.LocalizationSourceName;
        }
    }
}