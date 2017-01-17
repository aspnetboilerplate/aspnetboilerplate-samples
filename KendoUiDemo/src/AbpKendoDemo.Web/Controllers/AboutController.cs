using Microsoft.AspNetCore.Mvc;

namespace AbpKendoDemo.Web.Controllers
{
    public class AboutController : AbpKendoDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}