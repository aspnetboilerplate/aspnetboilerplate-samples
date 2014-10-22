using System.Web.Mvc;

namespace SimpleTaskSystem.WebSpaDurandal.Controllers
{
    public class HomeController : SimpleTaskSystemControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/shell.cshtml"); //Layout of the durandal application.
        }
	}
}