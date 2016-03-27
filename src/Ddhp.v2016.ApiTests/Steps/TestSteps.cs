using TechTalk.SpecFlow;
using Xunit;

namespace Ddhp.v2016.ApiTests.Steps
{
    [Binding]
    public class TestSteps
    {
        private bool _truth;

        [Given(@"a test")]
        public void ATest()
        {
            
        }

        [When(@"it's true")]
        public void ItsTrue()
        {
            _truth = true;
        }

        [Then(@"it's true1")]
        public void TotallyTrue()
        {
            Assert.Equal(true, _truth);
        }
    }
}