using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.TestHost;
using Xunit;

namespace Ddhp.v2016.ApiTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class PlayerTests
    {
        private readonly HttpClient _client;

        public PlayerTests()
        {
            var server = new TestServer(TestServer.CreateBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact]
        public async Task GetPlayers()
        {
            var response = await _client.GetAsync("/api/players");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("[\"First\",\"Second\"]", responseString);
        }
    }
}
