using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ddhp.v2016.ApiTests.DataSources;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Ddhp.v2016.ApiTests
{
    public class ClubContractsTests : InMemoryTestsBase
    {
        public ClubContractsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async void GetCurrentContractsForClub()
        {
            // Given it is round 5 2012
            var round = 201205;

            // And I am the Cheats
            var teamName = "Cheats";

            // When I request Contracts
            var response = await Client.GetAsync($"/api/contracts/{round}/{teamName}");
            response.EnsureSuccessStatusCode();

            var resultsAsync = await response.DeserializeJson<IEnumerable<Contract>>();
            var results = resultsAsync.ToList();

            _output.WriteLine(await response.Content.ReadAsStringAsync());

            // Then I have 24 contracts
            Assert.Equal(24, results.Count);
            
            // And the Players are loaded
            results.ForEach(q => Assert.NotNull(q.Player));
        }

        private readonly DdhpContext _ddhpContext = new InMemoryContext();
        private readonly ITestOutputHelper _output;

        protected override void ServicesToRegister(IServiceCollection collection)
        {
            collection.Add(new ServiceDescriptor(typeof(IDdhpContext), _ddhpContext));
        }

        public override void Dispose()
        {
            _ddhpContext.Dispose();
            base.Dispose();
        }
    }
}