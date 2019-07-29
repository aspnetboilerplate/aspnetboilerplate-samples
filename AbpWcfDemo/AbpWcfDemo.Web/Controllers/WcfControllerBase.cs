using Abp.Web.Mvc.Controllers;

namespace AbpWcfDemo.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class WcfControllerBase : AbpController
    {
        protected WcfControllerBase()
        {
            LocalizationSourceName = WcfConsts.LocalizationSourceName;
        }
    }
}