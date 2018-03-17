using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Volo.PostgreSqlDemo.Controllers;

namespace Volo.PostgreSqlDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : PostgreSqlDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
