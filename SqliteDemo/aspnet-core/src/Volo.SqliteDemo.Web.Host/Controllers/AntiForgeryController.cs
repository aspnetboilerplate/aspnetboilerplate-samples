using Microsoft.AspNetCore.Antiforgery;
using Volo.SqliteDemo.Controllers;

namespace Volo.SqliteDemo.Web.Host.Controllers
{
    public class AntiForgeryController : SqliteDemoControllerBase
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
