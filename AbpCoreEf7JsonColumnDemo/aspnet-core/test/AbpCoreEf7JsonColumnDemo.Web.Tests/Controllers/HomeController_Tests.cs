using System.Threading.Tasks;
using AbpCoreEf7JsonColumnDemo.Models.TokenAuth;
using AbpCoreEf7JsonColumnDemo.Web.Controllers;
using Shouldly;
using Xunit;

namespace AbpCoreEf7JsonColumnDemo.Web.Tests.Controllers
{
    public class HomeController_Tests: AbpCoreEf7JsonColumnDemoWebTestBase
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