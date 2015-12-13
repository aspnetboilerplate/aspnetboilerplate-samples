using Abp.Web.Mvc.Controllers;

namespace MultipleDbContextDemo.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class MultipleDbContextDemoControllerBase : AbpController
    {
        protected MultipleDbContextDemoControllerBase()
        {
            LocalizationSourceName = MultipleDbContextDemoConsts.LocalizationSourceName;
        }
    }
}