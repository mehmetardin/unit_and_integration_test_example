using Issuing.API;
using Issuing.Application.Dto.Card;
using IssuingAPI.IntegrationTests.Config;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace IssuingAPI.IntegrationTests.Controllers
{
    public class CardsControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CardsControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Create()
        {
            var response = await _client.PostAsJsonAsync("/api/cards", new CardCreateRequest { Bin = "abcdef", CardNo = "123456789" });
            var x = await response.Content.ReadAsStringAsync();

            var card = JsonConvert.DeserializeObject<CardCreateResponse>(x);
        }

        [Fact]
        public async Task GetCards()
        {
            var response = await _client.GetAsync("/api/cards");
            var x = await response.Content.ReadAsStringAsync();

            var cardList = JsonConvert.DeserializeObject<List<CardCreateResponse>>(x);
        }

        [Fact]
        public async Task GetById()
        {
            var response = await _client.GetAsync("/api/cards/1");
            var x = response;
        }
    }
}
