using Microsoft.AspNetCore.Antiforgery;
using AbpKendoDemo.Controllers;

namespace AbpKendoDemo.Web.Host.Controllers
{
    public class AntiForgeryController : AbpKendoDemoControllerBase
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
