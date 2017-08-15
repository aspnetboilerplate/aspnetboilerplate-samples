using System.Threading.Tasks;
using AbpPerformanceTestApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace AbpPerformanceTestApp.Web.Tests.Controllers
{
    public class HomeController_Tests: AbpPerformanceTestAppWebTestBase
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
