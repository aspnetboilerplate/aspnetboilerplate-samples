using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MassTransitSample.Controllers;

namespace MassTransitSample.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MassTransitSampleControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
