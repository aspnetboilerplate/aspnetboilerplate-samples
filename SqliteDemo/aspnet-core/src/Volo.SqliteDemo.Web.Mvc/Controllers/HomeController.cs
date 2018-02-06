using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Volo.SqliteDemo.Controllers;

namespace Volo.SqliteDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SqliteDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
