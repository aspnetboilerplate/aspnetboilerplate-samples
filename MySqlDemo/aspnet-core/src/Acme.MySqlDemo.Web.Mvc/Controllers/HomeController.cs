using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Acme.MySqlDemo.Controllers;

namespace Acme.MySqlDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MySqlDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
