using System.Threading.Tasks;
using IdentityServerDemo.Api.Web.Controllers;
using Shouldly;
using Xunit;

namespace IdentityServerDemo.Api.Web.Tests.Controllers
{
    public class HomeController_Tests: ApiWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
