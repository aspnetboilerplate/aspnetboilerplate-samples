using Microsoft.AspNetCore.Mvc;

namespace IdentityServerDemo.Api.Web.Controllers
{
    public class HomeController : ApiControllerBase
    {
        public ActionResult Index()
        {
            return Redirect("swagger");
        }
    }
}