using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpKendoDemo.Controllers;

namespace AbpKendoDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : AbpKendoDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
