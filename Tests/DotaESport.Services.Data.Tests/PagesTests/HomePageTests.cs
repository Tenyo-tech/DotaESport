namespace DotaESport.Services.Data.Tests.PagesTests
{
    using System.Threading.Tasks;

    using DotaESport.Web;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class HomePageTests
    {
        [Fact]
        public async Task HomePageShouldHaveTitle()
        {
            var serverFactory = new WebApplicationFactory<Startup>();
            var client = serverFactory.CreateClient();

            var response = await client.GetAsync("/");
            var responseAsString = await response.Content.ReadAsStringAsync();

            Assert.Contains("<h3", responseAsString);
        }
    }
}
