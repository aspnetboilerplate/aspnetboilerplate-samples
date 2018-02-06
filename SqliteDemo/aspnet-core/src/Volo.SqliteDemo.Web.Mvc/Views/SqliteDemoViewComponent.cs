using Abp.AspNetCore.Mvc.ViewComponents;

namespace Volo.SqliteDemo.Web.Views
{
    public abstract class SqliteDemoViewComponent : AbpViewComponent
    {
        protected SqliteDemoViewComponent()
        {
            LocalizationSourceName = SqliteDemoConsts.LocalizationSourceName;
        }
    }
}
