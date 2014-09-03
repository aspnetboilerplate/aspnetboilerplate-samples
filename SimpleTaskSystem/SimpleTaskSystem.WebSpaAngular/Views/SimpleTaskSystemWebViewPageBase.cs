using Abp.Web.Mvc.Views;

namespace SimpleTaskSystem.WebSpaAngular.Views
{
    public abstract class SimpleTaskSystemWebViewPageBase : SimpleTaskSystemWebViewPageBase<dynamic>
    {

    }

    public abstract class SimpleTaskSystemWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SimpleTaskSystemWebViewPageBase()
        {
            LocalizationSourceName = "SimpleTaskSystem";
        }
    }
}