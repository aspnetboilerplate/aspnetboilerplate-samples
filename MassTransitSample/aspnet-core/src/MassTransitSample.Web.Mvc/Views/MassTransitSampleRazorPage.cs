using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MassTransitSample.Web.Views
{
    public abstract class MassTransitSampleRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MassTransitSampleRazorPage()
        {
            LocalizationSourceName = MassTransitSampleConsts.LocalizationSourceName;
        }
    }
}
