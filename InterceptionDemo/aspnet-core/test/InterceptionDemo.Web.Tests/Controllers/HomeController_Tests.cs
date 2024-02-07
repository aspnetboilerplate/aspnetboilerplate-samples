using System.Threading.Tasks;
using InterceptionDemo.Models.TokenAuth;
using InterceptionDemo.Web.Controllers;
using Shouldly;
using Xunit;

namespace InterceptionDemo.Web.Tests.Controllers
{
    public class HomeController_Tests: InterceptionDemoWebTestBase
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