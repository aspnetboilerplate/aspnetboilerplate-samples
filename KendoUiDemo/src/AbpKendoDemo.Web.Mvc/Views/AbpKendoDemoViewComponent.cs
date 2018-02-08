using Abp.AspNetCore.Mvc.ViewComponents;

namespace AbpKendoDemo.Web.Views
{
    public abstract class AbpKendoDemoViewComponent : AbpViewComponent
    {
        protected AbpKendoDemoViewComponent()
        {
            LocalizationSourceName = AbpKendoDemoConsts.LocalizationSourceName;
        }
    }
}
