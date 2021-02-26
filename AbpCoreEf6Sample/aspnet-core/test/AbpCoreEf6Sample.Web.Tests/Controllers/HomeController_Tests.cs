using System.Threading.Tasks;
using AbpCoreEf6Sample.Models.TokenAuth;
using AbpCoreEf6Sample.Web.Controllers;
using Shouldly;
using Xunit;

namespace AbpCoreEf6Sample.Web.Tests.Controllers
{
    public class HomeController_Tests: AbpCoreEf6SampleWebTestBase
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