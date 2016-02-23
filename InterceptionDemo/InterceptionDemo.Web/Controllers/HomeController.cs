using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace InterceptionDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : InterceptionDemoControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}