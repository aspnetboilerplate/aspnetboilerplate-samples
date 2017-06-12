using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace IdentityServerDemo.Web.Views
{
    public abstract class IdentityServerDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected IdentityServerDemoRazorPage()
        {
            LocalizationSourceName = IdentityServerDemoConsts.LocalizationSourceName;
        }
    }
}
