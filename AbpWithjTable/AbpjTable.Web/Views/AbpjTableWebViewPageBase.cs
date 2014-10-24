using Abp.Web.Mvc.Views;

namespace AbpjTable.Web.Views
{
    public abstract class AbpjTableWebViewPageBase : AbpjTableWebViewPageBase<dynamic>
    {

    }

    public abstract class AbpjTableWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected AbpjTableWebViewPageBase()
        {
            LocalizationSourceName = AbpjTableConsts.LocalizationSourceName;
        }
    }
}