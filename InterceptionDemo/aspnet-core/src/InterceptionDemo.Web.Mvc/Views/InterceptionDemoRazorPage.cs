using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace InterceptionDemo.Web.Views
{
    public abstract class InterceptionDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected InterceptionDemoRazorPage()
        {
            LocalizationSourceName = InterceptionDemoConsts.LocalizationSourceName;
        }
    }
}
