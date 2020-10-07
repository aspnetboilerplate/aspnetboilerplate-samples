using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace IdentityServervNextDemo.Web.Views
{
    public abstract class IdentityServervNextDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected IdentityServervNextDemoRazorPage()
        {
            LocalizationSourceName = IdentityServervNextDemoConsts.LocalizationSourceName;
        }
    }
}
