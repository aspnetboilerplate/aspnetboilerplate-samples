using System.Web.Mvc;

namespace AbpWcfDemo.Web.Controllers
{
    public class AboutController : WcfControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}