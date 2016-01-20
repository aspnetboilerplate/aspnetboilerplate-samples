using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace BackgroundJobAndNotificationsDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BackgroundJobAndNotificationsDemoControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}