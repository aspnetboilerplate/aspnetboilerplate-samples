using Abp.AspNetCore.Mvc.ViewComponents;

namespace AbpCoreEf6Sample.Web.Views
{
    public abstract class AbpCoreEf6SampleViewComponent : AbpViewComponent
    {
        protected AbpCoreEf6SampleViewComponent()
        {
            LocalizationSourceName = AbpCoreEf6SampleConsts.LocalizationSourceName;
        }
    }
}
