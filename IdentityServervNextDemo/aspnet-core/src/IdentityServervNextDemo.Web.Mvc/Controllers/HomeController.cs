using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using IdentityServervNextDemo.Controllers;

namespace IdentityServervNextDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : IdentityServervNextDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
