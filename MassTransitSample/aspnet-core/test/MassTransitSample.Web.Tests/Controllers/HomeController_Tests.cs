using System.Threading.Tasks;
using MassTransitSample.Models.TokenAuth;
using MassTransitSample.Web.Controllers;
using Shouldly;
using Xunit;

namespace MassTransitSample.Web.Tests.Controllers
{
    public class HomeController_Tests: MassTransitSampleWebTestBase
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