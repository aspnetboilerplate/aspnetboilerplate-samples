using Abp.AspNetCore.Mvc.Authorization;
using AbpKendoDemo.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbpKendoDemo.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : AbpKendoDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}