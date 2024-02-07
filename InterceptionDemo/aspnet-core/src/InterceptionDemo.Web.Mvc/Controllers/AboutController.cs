using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using InterceptionDemo.Controllers;

namespace InterceptionDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : InterceptionDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
