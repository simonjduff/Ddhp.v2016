using Ddhp.v2016.ApiTests.TestContexts;
using Ddhp.v2016.Models.Ddhp;
using TechTalk.SpecFlow;
using Xunit;

namespace Ddhp.v2016.ApiTests.Steps
{
    [Binding]
    public class RoundSteps
    {
        private readonly TestContext _testContext;

        public RoundSteps(TestContext testContext)
        {
            _testContext = testContext;
        }

        private Round _round;

        [When("I request the next incomplete round")]
        public void GetIncompleteRound()
        {
            var url = $"/api/rounds/incomplete";
            _round = _testContext.GetResults<Round>(url).Result;
        }

        [Then(@"the round \d+ is returned")]
        public void RoundReturned(int roundId)
        {
            Assert.NotNull(_round);
            Assert.Equal(roundId, _round.Id);
        }
    }
}
