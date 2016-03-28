using Ddhp.v2016.ApiTests.TestContexts;
using TechTalk.SpecFlow;

namespace Ddhp.v2016.ApiTests.Steps
{
    [Binding]
    public class VariableSteps
    {
        private readonly TestContext _testContext;

        public VariableSteps(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Given(@"the round is (\d{6,6})")]
        public void SetRound(int roundId)
        {
            _testContext.RoundId = roundId;
        }

        [Given(@"my club is the (.*)")]
        public void SetClub(string clubName)
        {
            _testContext.ClubName = clubName;
        }
    }
}