using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbpKendoDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AbpKendoDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}