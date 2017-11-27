using Abp.AspNetCore.Mvc.Views;

namespace IdentityServerDemo.Api.Web.Views
{
    public abstract class ApiRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected ApiRazorPage()
        {
            LocalizationSourceName = ApiConsts.LocalizationSourceName;
        }
    }
}
