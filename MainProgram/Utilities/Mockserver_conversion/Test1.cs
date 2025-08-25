using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace MuseumApiTests
{
    public class MuseumApiTests
    {
        private RestClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient("https://redocly.com/_mock/docs/openapi/museum-api");
        }

        [Test]
        public async Task getMuseumHours_ShouldReturn200()
        {
            var request = new RestRequest("/museum-hours", Method.Get);
            var response = await _client.ExecuteAsync(request);
            NUnit.Framework.Assert.That((int)response.StatusCode, Is.EqualTo(200), "Expected status code 200");
        }

        [Test]
        public async Task createSpecialEvent_ShouldReturn201()
        {
            var request = new RestRequest("/special-events", Method.Post);
            var response = await _client.ExecuteAsync(request);
            NUnit.Framework.Assert.That((int)response.StatusCode, Is.EqualTo(201), "Expected status code 201");
        }

        [Test]
        public async Task listSpecialEvents_ShouldReturn200()
        {
            var request = new RestRequest("/special-events", Method.Get);
            var response = await _client.ExecuteAsync(request);
            NUnit.Framework.Assert.That((int)response.StatusCode, Is.EqualTo(200), "Expected status code 200");
        }

        [Test]
        public async Task getSpecialEvent_ShouldReturn200()
        {
            var request = new RestRequest("/special-events/{eventId}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            NUnit.Framework.Assert.That((int)response.StatusCode, Is.EqualTo(200), "Expected status code 200");
        }

        [Test]
        public async Task updateSpecialEvent_ShouldReturn200()
        {
            var request = new RestRequest("/special-events/{eventId}", Method.Patch);
            var response = await _client.ExecuteAsync(request);
            NUnit.Framework.Assert.That((int)response.StatusCode, Is.EqualTo(200), "Expected status code 200");
        }
    }
}
