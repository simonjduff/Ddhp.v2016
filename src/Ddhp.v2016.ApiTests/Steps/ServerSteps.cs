using Ddhp.v2016.ApiTests.TestContexts;
using Ddhp.v2016.Models;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace Ddhp.v2016.ApiTests.Steps
{
    [Binding]
    public class ServerSteps
    {
        private readonly TestContext _testContext;

        public ServerSteps(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Given(@"the in-memory webapi runner")]
        public void InMemoryWebApi()
        {
            var webHostBuilder = TestServer.CreateBuilder()
                .UseStartup<Startup>()
                .UseServices(q => q.Add(new ServiceDescriptor(typeof(IDdhpContext), _testContext.DataContext)));
            var server = new TestServer(webHostBuilder);
            _testContext.Client = server.CreateClient();
        }
    }
}