using _.UniveraHiringChallengeEntity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeTest
{
    public class AuthControllerTest:IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> _factory;
        
        public AuthControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task login_auth_test()
        {
            var user = new UserLoginDTO()
            {
                UserName="Admin",
                Password="123456",
                UserToken= "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXRhbGF5eW9sdWMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImF0YWxheXlvbHVjIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2Nzk2NjY3NjUsImlzcyI6ImxvY2FsaG9zdCIsImF1ZCI6ImxvY2FsaG9zdCJ9.0GxPOjxP0IVu-Cm3_o11gWeR3QMEhgm_FX0Oiv5LlB4"
            };
            
            var client=_factory.CreateClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/Auth", httpContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task register_auth_test()
        {
            var user = new UserDTO()
            {
                CountryId = Guid.Parse("06df1ff9-7dc9-4bae-aff0-bc681292c882"),
                Password = "123456",
                UserFirstName = "Deneme",
                UserLastName = "Test",
                UserName="Deneme"
            };
            var client = _factory.CreateClient();
            var httpContent=new StringContent(JsonConvert.SerializeObject(user),Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/auth/register", httpContent);
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }
    }
}
