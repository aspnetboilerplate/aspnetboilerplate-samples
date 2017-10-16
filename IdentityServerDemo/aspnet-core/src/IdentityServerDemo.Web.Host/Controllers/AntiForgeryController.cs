using Microsoft.AspNetCore.Antiforgery;
using IdentityServerDemo.Controllers;

namespace IdentityServerDemo.Web.Host.Controllers
{
    public class AntiForgeryController : IdentityServerDemoControllerBase
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
