using Abp.AspNetCore.Mvc.ViewComponents;

namespace HealthCheckExample.Web.Views
{
    public abstract class HealthCheckExampleViewComponent : AbpViewComponent
    {
        protected HealthCheckExampleViewComponent()
        {
            LocalizationSourceName = HealthCheckExampleConsts.LocalizationSourceName;
        }
    }
}
