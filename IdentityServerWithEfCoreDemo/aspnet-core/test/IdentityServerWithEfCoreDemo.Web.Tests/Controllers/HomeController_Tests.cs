using System.Threading.Tasks;
using IdentityServerWithEfCoreDemo.Models.TokenAuth;
using IdentityServerWithEfCoreDemo.Web.Controllers;
using Shouldly;
using Xunit;

namespace IdentityServerWithEfCoreDemo.Web.Tests.Controllers
{
    public class HomeController_Tests: IdentityServerWithEfCoreDemoWebTestBase
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