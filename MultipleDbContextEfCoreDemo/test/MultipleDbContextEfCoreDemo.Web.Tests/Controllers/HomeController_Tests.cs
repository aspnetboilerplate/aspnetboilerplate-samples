using System.Threading.Tasks;
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
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
