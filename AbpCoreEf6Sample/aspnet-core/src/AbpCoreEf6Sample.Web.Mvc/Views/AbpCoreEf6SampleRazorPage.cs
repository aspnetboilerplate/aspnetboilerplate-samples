using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AbpCoreEf6Sample.Web.Views
{
    public abstract class AbpCoreEf6SampleRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpCoreEf6SampleRazorPage()
        {
            LocalizationSourceName = AbpCoreEf6SampleConsts.LocalizationSourceName;
        }
    }
}
