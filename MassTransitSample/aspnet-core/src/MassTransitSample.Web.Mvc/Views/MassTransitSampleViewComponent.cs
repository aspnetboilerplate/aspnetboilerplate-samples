using Abp.AspNetCore.Mvc.ViewComponents;

namespace MassTransitSample.Web.Views
{
    public abstract class MassTransitSampleViewComponent : AbpViewComponent
    {
        protected MassTransitSampleViewComponent()
        {
            LocalizationSourceName = MassTransitSampleConsts.LocalizationSourceName;
        }
    }
}
