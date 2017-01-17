using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using AbpKendoDemo.Authorization;
using AbpKendoDemo.Users;
using Microsoft.AspNetCore.Mvc;

namespace AbpKendoDemo.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : AbpKendoDemoControllerBase
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