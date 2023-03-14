using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AbpCoreEf7JsonColumnDemo.Web.Views
{
    public abstract class AbpCoreEf7JsonColumnDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpCoreEf7JsonColumnDemoRazorPage()
        {
            LocalizationSourceName = AbpCoreEf7JsonColumnDemoConsts.LocalizationSourceName;
        }
    }
}
