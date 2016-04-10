using System.Collections.Generic;
using Ddhp.v2016.Models.Ddhp;
using System.Linq;
using Ddhp.v2016.ApiTests.TestContexts;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Ddhp.v2016.ApiTests.Steps
{
    [Binding]
    public class ContractSteps
    {
        public ContractSteps(TestContext testContext)
        {
            _testContext = testContext;
        }

        private List<Contract> _results;
        private readonly TestContext _testContext;

        [When(@"I request contracts for the club and round")]
        public void GetContracts()
        {
            var url = $"/api/contracts/{_testContext.RoundId}/{_testContext.ClubName}";
            _results = _testContext.GetResults<List<Contract>>(url).ToList();
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

        // ReSharper disable once ClassNeverInstantiated.Local
        private class ExpectedPlayers
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int FromRoundId { get; set; }
            public int ToRoundId { get; set; }
        }
    }
}
