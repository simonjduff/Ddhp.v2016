using System.Net.Http;
using System.Threading.Tasks;
using Ddhp.v2016.ApiTests.DataSources;

namespace Ddhp.v2016.ApiTests.TestContexts
{
    public class TestContext
    {
        public InMemoryContext DataContext { get; set; }
        public HttpClient Client { get; set; }
        public int RoundId { get; set; }
        public string ClubName { get; set; }

        public async Task<T> GetResults<T>(string url)
        {
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var resultsAsync = await response.DeserializeJson<T>();
            return resultsAsync;
        }
    }
}