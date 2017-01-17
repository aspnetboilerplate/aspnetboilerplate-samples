using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AbpKendoDemo.Web.Views
{
    public abstract class AbpKendoDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpKendoDemoRazorPage()
        {
            LocalizationSourceName = AbpKendoDemoConsts.LocalizationSourceName;
        }
    }
}
