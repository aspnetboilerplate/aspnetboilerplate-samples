using Acme.PhoneBook.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Acme.PhoneBook.Web.Controllers
{
    public class AboutController : PhoneBookControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}