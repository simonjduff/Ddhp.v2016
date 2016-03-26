using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Ddhp.v2016.ApiTests
{
    public abstract class InMemoryTestsBase : IDisposable
    {
        private HttpClient _client;

        protected HttpClient Client => _client ?? BuildClient();

        private HttpClient BuildClient()
        {
            var webHostBuilder = TestServer.CreateBuilder()
                .UseStartup<Startup>()
                .UseServices(ServicesToRegister);
            var server = new TestServer(webHostBuilder);
            _client = server.CreateClient();
            return _client;
        }

        protected virtual void ServicesToRegister(IServiceCollection collection)
        {
        }

        public virtual void Dispose()
        {
            Client.Dispose();
        }

        protected async Task<T> GetResults<T>(string url)
        {
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var resultsAsync = await response.DeserializeJson<T>();
            return resultsAsync;
        }
    }
}