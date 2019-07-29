using Abp.Web.Mvc.Views;

namespace AbpWcfDemo.Web.Views
{
    public abstract class SoapWebViewPageBase : SoapWebViewPageBase<dynamic>
    {

    }

    public abstract class SoapWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SoapWebViewPageBase()
        {
            LocalizationSourceName = WcfConsts.LocalizationSourceName;
        }
    }
}