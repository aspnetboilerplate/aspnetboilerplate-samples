using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using IdentityServervNextDemo.Controllers;

namespace IdentityServervNextDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : IdentityServervNextDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
