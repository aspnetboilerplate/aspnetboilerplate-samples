using Microsoft.AspNetCore.Antiforgery;
using Volo.PostgreSqlDemo.Controllers;

namespace Volo.PostgreSqlDemo.Web.Host.Controllers
{
    public class AntiForgeryController : PostgreSqlDemoControllerBase
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
