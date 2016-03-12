using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ddhp.v2016.ApiTests
{
    public static class TestExtensions
    {
        public static async Task<T> DeserializeJson<T>(this HttpResponseMessage message)
        {
            var value = await message.Content.ReadAsStringAsync();
            return (T) JsonConvert.DeserializeObject(value, typeof(T));
        }
    }
}