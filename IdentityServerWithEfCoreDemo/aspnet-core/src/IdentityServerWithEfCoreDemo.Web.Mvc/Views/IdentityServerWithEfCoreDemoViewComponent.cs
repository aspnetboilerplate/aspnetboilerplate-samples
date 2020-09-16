using Abp.AspNetCore.Mvc.ViewComponents;

namespace IdentityServerWithEfCoreDemo.Web.Views
{
    public abstract class IdentityServerWithEfCoreDemoViewComponent : AbpViewComponent
    {
        protected IdentityServerWithEfCoreDemoViewComponent()
        {
            LocalizationSourceName = IdentityServerWithEfCoreDemoConsts.LocalizationSourceName;
        }
    }
}
