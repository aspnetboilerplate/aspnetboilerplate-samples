using System.Web.Mvc;

namespace SimpleTaskSystem.Web.Controllers
{
    public class HomeController : SimpleTaskSystemControllerBase
    {
        public ActionResult Index()
        { 
            return View();
        }
	}
}