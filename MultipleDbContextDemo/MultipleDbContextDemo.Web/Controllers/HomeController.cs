using System.Web.Mvc;

namespace MultipleDbContextDemo.Web.Controllers
{
    public class HomeController : MultipleDbContextDemoControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}