using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AbpCoreEf7JsonColumnDemo.Controllers;

namespace AbpCoreEf7JsonColumnDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AbpCoreEf7JsonColumnDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
