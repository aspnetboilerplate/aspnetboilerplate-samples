using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Volo.PostgreSqlDemo.Web.Views
{
    public abstract class PostgreSqlDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PostgreSqlDemoRazorPage()
        {
            LocalizationSourceName = PostgreSqlDemoConsts.LocalizationSourceName;
        }
    }
}
