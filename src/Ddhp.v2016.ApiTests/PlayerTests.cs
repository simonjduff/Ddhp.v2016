using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ddhp.v2016.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNet.TestHost;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NSubstitute;
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
            var optionsBuilder = new DbContextOptionsBuilder<DdhpContext>();
            optionsBuilder.UseInMemoryDatabase();
            var ddhpContext = new DdhpContext(optionsBuilder.Options);

            ddhpContext.Players.Add(new Player {FirstName = "First", LastName = "Second"});
            ddhpContext.SaveChanges();

            var server = new TestServer(TestServer.CreateBuilder()
                .UseStartup<Startup>()
                .UseServices(q => q.Add(new ServiceDescriptor(typeof(IDdhpContext), ddhpContext))));
            _client = server.CreateClient();
        }

        [Fact]
        public async Task GetPlayers()
        {
            var response = await _client.GetAsync("/api/players");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var results = (IEnumerable<Player>)JsonConvert.DeserializeObject(responseString, typeof (IEnumerable<Player>));

            Assert.Equal(1, results.Count());
            var player = results.First();
            Trace.WriteLine(player.ToString());
            Assert.Equal("First", player.FirstName);
            Assert.Equal("Second", player.LastName);
        }
    }
}
