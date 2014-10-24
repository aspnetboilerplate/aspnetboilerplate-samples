using System.Web.Mvc;

namespace AbpjTable.Web.Controllers
{
    public class HomeController : AbpjTableControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}