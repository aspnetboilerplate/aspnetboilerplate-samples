using Abp.AspNetCore.Mvc.ViewComponents;

namespace MultipleDbContextEfCoreDemo.Web.Views
{
    public abstract class MultipleDbContextEfCoreDemoViewComponent : AbpViewComponent
    {
        protected MultipleDbContextEfCoreDemoViewComponent()
        {
            LocalizationSourceName = MultipleDbContextEfCoreDemoConsts.LocalizationSourceName;
        }
    }
}
