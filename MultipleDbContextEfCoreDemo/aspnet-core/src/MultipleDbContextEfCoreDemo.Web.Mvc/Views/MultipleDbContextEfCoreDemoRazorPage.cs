using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MultipleDbContextEfCoreDemo.Web.Views
{
    public abstract class MultipleDbContextEfCoreDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MultipleDbContextEfCoreDemoRazorPage()
        {
            LocalizationSourceName = MultipleDbContextEfCoreDemoConsts.LocalizationSourceName;
        }
    }
}
