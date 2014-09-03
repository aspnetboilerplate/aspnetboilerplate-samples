using Abp.Web.Mvc.Controllers;

namespace SimpleTaskSystem.WebSpaDurandal.Controllers
{
    public abstract class SimpleTaskSystemControllerBase : AbpController
    {
        protected SimpleTaskSystemControllerBase()
        {
            LocalizationSourceName = "SimpleTaskSystem";
        }
    }
}