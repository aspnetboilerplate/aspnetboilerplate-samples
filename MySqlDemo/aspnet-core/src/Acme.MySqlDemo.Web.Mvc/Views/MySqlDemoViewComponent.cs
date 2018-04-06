using Abp.AspNetCore.Mvc.ViewComponents;

namespace Acme.MySqlDemo.Web.Views
{
    public abstract class MySqlDemoViewComponent : AbpViewComponent
    {
        protected MySqlDemoViewComponent()
        {
            LocalizationSourceName = MySqlDemoConsts.LocalizationSourceName;
        }
    }
}
