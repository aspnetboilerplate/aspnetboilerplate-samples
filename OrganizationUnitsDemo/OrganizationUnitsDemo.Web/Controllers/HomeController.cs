using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace OrganizationUnitsDemo.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : OrganizationUnitsDemoControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}