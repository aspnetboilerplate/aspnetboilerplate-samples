using Abp.AspNetCore.Mvc.Views;

namespace MultipleDbContextEfCoreDemo.Web.Views
{
    public abstract class MultipleDbContextEfCoreDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected MultipleDbContextEfCoreDemoRazorPage()
        {
            LocalizationSourceName = MultipleDbContextEfCoreDemoConsts.LocalizationSourceName;
        }
    }
}
