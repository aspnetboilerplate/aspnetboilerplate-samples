using Abp.Web.Mvc.Controllers;

namespace AbpjTable.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class AbpjTableControllerBase : AbpController
    {
        protected AbpjTableControllerBase()
        {
            LocalizationSourceName = AbpjTableConsts.LocalizationSourceName;
        }
    }
}