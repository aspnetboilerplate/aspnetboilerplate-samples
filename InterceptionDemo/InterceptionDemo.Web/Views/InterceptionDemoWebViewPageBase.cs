using Abp.Web.Mvc.Views;

namespace InterceptionDemo.Web.Views
{
    public abstract class InterceptionDemoWebViewPageBase : InterceptionDemoWebViewPageBase<dynamic>
    {

    }

    public abstract class InterceptionDemoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected InterceptionDemoWebViewPageBase()
        {
            LocalizationSourceName = InterceptionDemoConsts.LocalizationSourceName;
        }
    }
}