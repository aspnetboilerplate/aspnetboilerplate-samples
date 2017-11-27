using Abp.AspNetCore.Mvc.Controllers;

namespace IdentityServerDemo.Api.Web.Controllers
{
    public abstract class ApiControllerBase: AbpController
    {
        protected ApiControllerBase()
        {
            LocalizationSourceName = ApiConsts.LocalizationSourceName;
        }
    }
}