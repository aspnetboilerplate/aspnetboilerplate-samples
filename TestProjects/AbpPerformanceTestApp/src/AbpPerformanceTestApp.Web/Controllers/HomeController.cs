using Microsoft.AspNetCore.Mvc;

namespace AbpPerformanceTestApp.Web.Controllers
{
    public class HomeController : AbpPerformanceTestAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}