using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ddhp.v2016.Models;
using Microsoft.AspNet.TestHost;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Ddhp.v2016.ApiTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class PlayerTests : InMemoryTestsBase
    {
        private readonly ITestOutputHelper _output;
        

        public PlayerTests(ITestOutputHelper output)
        {
            _output = output;

            DdhpContext.Players.Add(new Player { FirstName = "First1", LastName = "Second1" });
            DdhpContext.Players.Add(new Player { FirstName = "First2", LastName = "Second2" });
            DdhpContext.SaveChanges();
        }

        [Fact]
        public async Task GetPlayers()
        {
            var response = await _client.GetAsync("/api/players");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var results = (IEnumerable<Player>)JsonConvert.DeserializeObject(responseString, typeof (IEnumerable<Player>));

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
            var response = await _client.GetAsync("/api/players/1");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var player = (Player)JsonConvert.DeserializeObject(responseString, typeof(Player));

            Assert.Equal("First1", player.FirstName);
            Assert.Equal("Second1", player.LastName);
        }
    }
}
