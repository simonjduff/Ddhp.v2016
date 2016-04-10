using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ddhp.v2016.ApiTests.DataSources;

namespace Ddhp.v2016.ApiTests.TestContexts
{
    public class TestContext : IDisposable
    {
        public InMemoryContext DataContext { get; set; }
        public HttpClient Client { get; set; }
        public int RoundId { get; set; }
        public string ClubName { get; set; }

        public Task<T> GetResults<T>(string url)
        {
            var response = Client.GetAsync(url);
            response.Result.EnsureSuccessStatusCode();

            var resultsAsync = response.Result.DeserializeJson<T>();
            return resultsAsync;
        }

        public void Dispose()
        {
            DataContext?.Dispose();
            Client?.Dispose();
        }
    }
}