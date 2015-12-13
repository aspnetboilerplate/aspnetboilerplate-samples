using Abp.Web.Mvc.Views;

namespace MultipleDbContextDemo.Web.Views
{
    public abstract class MultipleDbContextDemoWebViewPageBase : MultipleDbContextDemoWebViewPageBase<dynamic>
    {

    }

    public abstract class MultipleDbContextDemoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected MultipleDbContextDemoWebViewPageBase()
        {
            LocalizationSourceName = MultipleDbContextDemoConsts.LocalizationSourceName;
        }
    }
}