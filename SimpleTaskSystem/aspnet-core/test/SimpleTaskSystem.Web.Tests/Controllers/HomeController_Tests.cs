using System.Threading.Tasks;
using SimpleTaskSystem.Models.TokenAuth;
using SimpleTaskSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace SimpleTaskSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: SimpleTaskSystemWebTestBase
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