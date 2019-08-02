using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace HealthCheckExample.Web.Views
{
    public abstract class HealthCheckExampleRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected HealthCheckExampleRazorPage()
        {
            LocalizationSourceName = HealthCheckExampleConsts.LocalizationSourceName;
        }
    }
}
