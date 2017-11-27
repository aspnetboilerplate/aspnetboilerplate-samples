using Microsoft.AspNetCore.Antiforgery;
using IdentityServerDemo.SSO.Controllers;

namespace IdentityServerDemo.SSO.Web.Host.Controllers
{
    public class AntiForgeryController : SSOControllerBase
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
