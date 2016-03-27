using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ddhp.v2016.ApiTests.DataSources;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Ddhp.v2016.ApiTests.Steps
{
    [Binding]
    public class ContractSteps
    {
        private InMemoryContext _context;
        private HttpClient _client;
        private int _roundId;
        private string _clubName;
        private List<Contract> _results;

        [Given(@"the test data from 2012 with in-memory database")]
        public void LoadTestData()
        {
            _context = new InMemoryContext();
        }

        [Given(@"the in-memory webapi runner")]
        public void InMemoryWebApi()
        {
            var webHostBuilder = TestServer.CreateBuilder()
                .UseStartup<Startup>()
                .UseServices(q => q.Add(new ServiceDescriptor(typeof(IDdhpContext), _context)));
            var server = new TestServer(webHostBuilder);
            _client = server.CreateClient();
        }

        [Given(@"the round is (\d{6,6})")]
        public void SetRound(int roundId)
        {
            _roundId = roundId;
        }

        [Given(@"my club is the (.*)")]
        public void SetClub(string clubName)
        {
            _clubName = clubName;
        }

        [When(@"I request contracts for the club and round")]
        public void GetContracts()
        {
            var url = $"/api/contracts/{_roundId}/{_clubName}";
            _results = GetResults<List<Contract>>(url).Result.ToList();
        }

        [Then(@"I have (\d+) contracts returned")]
        public void ContractsCount(int expectedCount)
        {
            Assert.Equal(expectedCount, _results.Count);
        }

        [Then(@"the following contracts are returned:")]
        public void CheckPlayers(Table expectedPlayers)
        {
            var expected = expectedPlayers.CreateSet<ExpectedPlayers>();
            foreach (var player in expected)
            {
                Assert.Contains(_results, q => q.Player.FirstName == player.FirstName
                    && q.Player.LastName == player.LastName
                    && q.FromRoundId == player.FromRoundId
                    && q.ToRoundId == player.ToRoundId);
            }
        }

        private class ExpectedPlayers
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int FromRoundId { get; set; }
            public int ToRoundId { get; set; }
        }

        protected async Task<T> GetResults<T>(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var resultsAsync = await response.DeserializeJson<T>();
            return resultsAsync;
        }
    }
}
