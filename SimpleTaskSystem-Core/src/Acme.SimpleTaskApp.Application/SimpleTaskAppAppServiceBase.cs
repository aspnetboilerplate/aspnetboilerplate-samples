using Abp.Application.Services;

namespace Acme.SimpleTaskApp
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SimpleTaskAppAppServiceBase : ApplicationService
    {
        protected SimpleTaskAppAppServiceBase()
        {
            LocalizationSourceName = SimpleTaskAppConsts.LocalizationSourceName;
        }
    }
}