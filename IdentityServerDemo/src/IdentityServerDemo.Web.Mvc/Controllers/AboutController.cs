using IdentityServerDemo.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerDemo.Web.Controllers
{
    public class AboutController : IdentityServerDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}