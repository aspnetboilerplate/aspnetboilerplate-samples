using Microsoft.AspNetCore.Mvc;

namespace Acme.SimpleTaskApp.Web.Controllers
{
    public class HomeController : SimpleTaskAppControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Tasks");
        }
    }
}