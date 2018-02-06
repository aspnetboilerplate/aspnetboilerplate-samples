using Abp.AspNetCore.Mvc.ViewComponents;

namespace Volo.PostgreSqlDemo.Web.Views
{
    public abstract class PostgreSqlDemoViewComponent : AbpViewComponent
    {
        protected PostgreSqlDemoViewComponent()
        {
            LocalizationSourceName = PostgreSqlDemoConsts.LocalizationSourceName;
        }
    }
}
