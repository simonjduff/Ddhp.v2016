using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ddhp.v2016.Models;
using Xunit;
using Xunit.Abstractions;

namespace Ddhp.v2016.ApiTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    [Collection("InMemory")]
    public class PlayerTests : InMemoryTestsBase
    {
        private readonly ITestOutputHelper _output;
        

        public PlayerTests(ITestOutputHelper output)
        {
            _output = output;

            DdhpContext.Players.Add(new Player {Id = 1, FirstName = "First1", LastName = "Second1" });
            DdhpContext.Players.Add(new Player { Id = 2, FirstName = "First2", LastName = "Second2" });
            DdhpContext.SaveChanges();
        }

        [Fact]
        public async Task GetPlayers()
        {
            var response = await Client.GetAsync("/api/players");
            response.EnsureSuccessStatusCode();

            var results = await response.DeserializeJson<IEnumerable<Player>>();

            foreach (var result in results)
            {
                _output.WriteLine($"{result.Id} {result.FirstName} {result.LastName}");
            }

            Assert.Equal(2, results.Count());
            var player = results.First();

            Assert.Equal("First1", player.FirstName);
            Assert.Equal("Second1", player.LastName);
        }

        [Fact]
        public async Task GetPlayerById()
        {
            var response = await Client.GetAsync("/api/players/1");
            response.EnsureSuccessStatusCode();

            var player = await response.DeserializeJson<Player>();

            Assert.Equal("First1", player.FirstName);
            Assert.Equal("Second1", player.LastName);
        }
    }
}
