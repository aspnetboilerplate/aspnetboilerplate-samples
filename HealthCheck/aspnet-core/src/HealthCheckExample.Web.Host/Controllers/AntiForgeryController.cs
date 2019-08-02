using Microsoft.AspNetCore.Antiforgery;
using HealthCheckExample.Controllers;

namespace HealthCheckExample.Web.Host.Controllers
{
    public class AntiForgeryController : HealthCheckExampleControllerBase
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
