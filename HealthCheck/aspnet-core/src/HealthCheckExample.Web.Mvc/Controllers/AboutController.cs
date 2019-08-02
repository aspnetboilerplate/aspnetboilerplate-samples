using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using HealthCheckExample.Controllers;

namespace HealthCheckExample.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : HealthCheckExampleControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
