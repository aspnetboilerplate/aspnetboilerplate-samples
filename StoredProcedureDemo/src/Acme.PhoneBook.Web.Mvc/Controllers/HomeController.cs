using Abp.AspNetCore.Mvc.Authorization;
using Acme.PhoneBook.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Acme.PhoneBook.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PhoneBookControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}