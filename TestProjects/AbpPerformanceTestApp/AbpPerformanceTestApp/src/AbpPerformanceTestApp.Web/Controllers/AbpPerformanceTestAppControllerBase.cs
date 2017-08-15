using Abp.AspNetCore.Mvc.Controllers;

namespace AbpPerformanceTestApp.Web.Controllers
{
    public abstract class AbpPerformanceTestAppControllerBase: AbpController
    {
        protected AbpPerformanceTestAppControllerBase()
        {
            LocalizationSourceName = AbpPerformanceTestAppConsts.LocalizationSourceName;
        }
    }
}