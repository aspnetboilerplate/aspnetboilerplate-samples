using Abp.Application.Services;

namespace MultipleDbContextEfCoreDemo
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MultipleDbContextEfCoreDemoAppServiceBase : ApplicationService
    {
        protected MultipleDbContextEfCoreDemoAppServiceBase()
        {
            LocalizationSourceName = MultipleDbContextEfCoreDemoConsts.LocalizationSourceName;
        }
    }
}