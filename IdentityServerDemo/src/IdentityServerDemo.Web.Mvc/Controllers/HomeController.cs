using Abp.AspNetCore.Mvc.Authorization;
using IdentityServerDemo.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : IdentityServerDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}