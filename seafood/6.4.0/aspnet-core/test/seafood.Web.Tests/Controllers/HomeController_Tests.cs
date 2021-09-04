using System.Threading.Tasks;
using seafood.Models.TokenAuth;
using seafood.Web.Controllers;
using Shouldly;
using Xunit;

namespace seafood.Web.Tests.Controllers
{
    public class HomeController_Tests: seafoodWebTestBase
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