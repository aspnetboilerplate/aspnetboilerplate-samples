using Abp.AspNetCore.Mvc.ViewComponents;

namespace AbpCoreEf7JsonColumnDemo.Web.Views
{
    public abstract class AbpCoreEf7JsonColumnDemoViewComponent : AbpViewComponent
    {
        protected AbpCoreEf7JsonColumnDemoViewComponent()
        {
            LocalizationSourceName = AbpCoreEf7JsonColumnDemoConsts.LocalizationSourceName;
        }
    }
}
