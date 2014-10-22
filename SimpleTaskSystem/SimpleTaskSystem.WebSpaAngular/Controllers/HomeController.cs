using System.Web.Mvc;

namespace SimpleTaskSystem.WebSpaAngular.Controllers
{
    public class HomeController : SimpleTaskSystemControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}