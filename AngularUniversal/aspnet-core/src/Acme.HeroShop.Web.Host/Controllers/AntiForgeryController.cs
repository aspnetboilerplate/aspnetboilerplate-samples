using Microsoft.AspNetCore.Antiforgery;
using Acme.HeroShop.Controllers;

namespace Acme.HeroShop.Web.Host.Controllers
{
    public class AntiForgeryController : HeroShopControllerBase
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
