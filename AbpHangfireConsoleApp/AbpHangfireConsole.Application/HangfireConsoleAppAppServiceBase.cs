using Abp.Application.Services;
using AbpHangfireConsole.Core;

namespace AbpHangfireConsole.Application
{
    /// <summary>
    ///     Derive your application services from this class.
    /// </summary>
    public abstract class HangfireConsoleAppAppServiceBase : ApplicationService
    {
        protected HangfireConsoleAppAppServiceBase()
        {
            LocalizationSourceName = AbpHangfireConsoleConsts.LocalizationSourceName;
        }
    }
}