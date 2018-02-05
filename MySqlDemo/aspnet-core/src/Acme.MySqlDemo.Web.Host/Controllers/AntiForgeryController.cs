using Microsoft.AspNetCore.Antiforgery;
using Acme.MySqlDemo.Controllers;

namespace Acme.MySqlDemo.Web.Host.Controllers
{
    public class AntiForgeryController : MySqlDemoControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
