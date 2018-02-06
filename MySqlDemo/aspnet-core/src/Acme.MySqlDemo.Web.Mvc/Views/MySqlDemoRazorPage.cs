using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Acme.MySqlDemo.Web.Views
{
    public abstract class MySqlDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MySqlDemoRazorPage()
        {
            LocalizationSourceName = MySqlDemoConsts.LocalizationSourceName;
        }
    }
}
