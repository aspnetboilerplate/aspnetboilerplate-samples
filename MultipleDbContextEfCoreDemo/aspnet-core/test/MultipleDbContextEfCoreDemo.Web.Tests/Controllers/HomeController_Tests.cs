using System.Threading.Tasks;
using MultipleDbContextEfCoreDemo.Models.TokenAuth;
using MultipleDbContextEfCoreDemo.Web.Controllers;
using Shouldly;
using Xunit;

namespace MultipleDbContextEfCoreDemo.Web.Tests.Controllers
{
    public class HomeController_Tests: MultipleDbContextEfCoreDemoWebTestBase
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