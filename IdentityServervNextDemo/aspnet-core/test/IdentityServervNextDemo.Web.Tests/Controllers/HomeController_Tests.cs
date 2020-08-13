using System.Threading.Tasks;
using IdentityServervNextDemo.Models.TokenAuth;
using IdentityServervNextDemo.Web.Controllers;
using Shouldly;
using Xunit;

namespace IdentityServervNextDemo.Web.Tests.Controllers
{
    public class HomeController_Tests: IdentityServervNextDemoWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}