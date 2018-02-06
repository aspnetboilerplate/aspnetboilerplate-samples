using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Volo.SqliteDemo.Web.Views
{
    public abstract class SqliteDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected SqliteDemoRazorPage()
        {
            LocalizationSourceName = SqliteDemoConsts.LocalizationSourceName;
        }
    }
}
