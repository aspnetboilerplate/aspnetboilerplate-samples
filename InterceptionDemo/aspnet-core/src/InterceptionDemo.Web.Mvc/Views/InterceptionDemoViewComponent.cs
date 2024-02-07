using Abp.AspNetCore.Mvc.ViewComponents;

namespace InterceptionDemo.Web.Views
{
    public abstract class InterceptionDemoViewComponent : AbpViewComponent
    {
        protected InterceptionDemoViewComponent()
        {
            LocalizationSourceName = InterceptionDemoConsts.LocalizationSourceName;
        }
    }
}
