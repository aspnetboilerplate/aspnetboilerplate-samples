using Abp.AspNetCore.Mvc.Views;

namespace AbpPerformanceTestApp.Web.Views
{
    public abstract class AbpPerformanceTestAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected AbpPerformanceTestAppRazorPage()
        {
            LocalizationSourceName = AbpPerformanceTestAppConsts.LocalizationSourceName;
        }
    }
}
