using Acme.ProjectName.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace Acme.ProjectName.Web.Host.Controllers
{
    public class AntiForgeryController : ProjectNameControllerBase
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