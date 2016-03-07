using Abp.Web.Mvc.Views;

namespace PlugInDemo.Web.Views
{
    public abstract class PlugInDemoWebViewPageBase : PlugInDemoWebViewPageBase<dynamic>
    {

    }

    public abstract class PlugInDemoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected PlugInDemoWebViewPageBase()
        {
            LocalizationSourceName = PlugInDemoConsts.LocalizationSourceName;
        }
    }
}