using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using IdentityServerDemo.Authorization;
using IdentityServerDemo.Controllers;
using IdentityServerDemo.Users;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerDemo.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : IdentityServerDemoControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}