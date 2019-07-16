using Microsoft.AspNetCore.Antiforgery;
using Hotel.Controllers;

namespace Hotel.Web.Host.Controllers
{
    public class AntiForgeryController : HotelControllerBase
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
