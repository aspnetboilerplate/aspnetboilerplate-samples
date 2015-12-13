using Abp.Application.Services;

namespace MultipleDbContextDemo
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MultipleDbContextDemoAppServiceBase : ApplicationService
    {
        protected MultipleDbContextDemoAppServiceBase()
        {
            LocalizationSourceName = MultipleDbContextDemoConsts.LocalizationSourceName;
        }
    }
}