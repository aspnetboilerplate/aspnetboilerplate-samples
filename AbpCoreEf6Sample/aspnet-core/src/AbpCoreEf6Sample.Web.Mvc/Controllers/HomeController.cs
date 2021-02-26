using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCoreEf6Sample.Controllers;

namespace AbpCoreEf6Sample.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AbpCoreEf6SampleControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
