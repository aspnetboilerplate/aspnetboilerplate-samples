using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace IdentityServerWithEfCoreDemo.Web.Views
{
    public abstract class IdentityServerWithEfCoreDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected IdentityServerWithEfCoreDemoRazorPage()
        {
            LocalizationSourceName = IdentityServerWithEfCoreDemoConsts.LocalizationSourceName;
        }
    }
}
