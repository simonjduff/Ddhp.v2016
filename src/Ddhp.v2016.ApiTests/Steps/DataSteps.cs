using Ddhp.v2016.ApiTests.DataSources;
using Ddhp.v2016.ApiTests.TestContexts;
using TechTalk.SpecFlow;

namespace Ddhp.v2016.ApiTests.Steps
{
    [Binding]
    public class DataSteps
    {
        private readonly TestContext _testContext;

        public DataSteps(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Given(@"the test data from 2012 with in-memory database")]
        public void LoadTestData()
        {
            _testContext.DataContext = new InMemoryContext();
        }
    }
}