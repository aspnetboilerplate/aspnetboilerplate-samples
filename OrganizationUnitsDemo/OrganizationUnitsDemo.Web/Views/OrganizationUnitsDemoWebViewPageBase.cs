using Abp.Web.Mvc.Views;

namespace OrganizationUnitsDemo.Web.Views
{
    public abstract class OrganizationUnitsDemoWebViewPageBase : OrganizationUnitsDemoWebViewPageBase<dynamic>
    {

    }

    public abstract class OrganizationUnitsDemoWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected OrganizationUnitsDemoWebViewPageBase()
        {
            LocalizationSourceName = OrganizationUnitsDemoConsts.LocalizationSourceName;
        }
    }
}