using _.UniveraHiringChallengeEntity.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeTest
{
    public class CountryControllerTest:IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> _factory;

        public CountryControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task get_country_test()
        {
            var client=_factory.CreateClient();
            
            var response = await client.GetAsync("/api/country");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task post_country_test()
        {
            var country = new CountryDTO() { CountryName = "Ülke",CountryImageUrl="testImg" };
            var client = _factory.CreateClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/country", httpContent);
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }
    }
}
