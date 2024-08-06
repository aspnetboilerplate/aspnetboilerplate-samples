using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MultipleDbContextEfCoreDemo.Controllers;

namespace MultipleDbContextEfCoreDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MultipleDbContextEfCoreDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
