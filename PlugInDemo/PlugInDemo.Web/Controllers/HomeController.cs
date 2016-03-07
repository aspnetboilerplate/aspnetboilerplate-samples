using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace PlugInDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PlugInDemoControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}