using Abp.Web.Mvc.Controllers;

namespace SimpleTaskSystem.WebSpaAngular.Controllers
{
    public abstract class SimpleTaskSystemControllerBase : AbpController
    {
        protected SimpleTaskSystemControllerBase()
        {
            LocalizationSourceName = "SimpleTaskSystem";
        }
    }
}