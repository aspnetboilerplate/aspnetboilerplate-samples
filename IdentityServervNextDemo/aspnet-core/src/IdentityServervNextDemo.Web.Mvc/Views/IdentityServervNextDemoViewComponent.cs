using Abp.AspNetCore.Mvc.ViewComponents;

namespace IdentityServervNextDemo.Web.Views
{
    public abstract class IdentityServervNextDemoViewComponent : AbpViewComponent
    {
        protected IdentityServervNextDemoViewComponent()
        {
            LocalizationSourceName = IdentityServervNextDemoConsts.LocalizationSourceName;
        }
    }
}
