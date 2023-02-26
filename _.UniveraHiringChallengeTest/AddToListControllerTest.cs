using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeTest
{
    public class AddToListControllerTest:IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> _factory;

        public AddToListControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task addtolist_addtolist_test()
        {
            var list = new AddProductForShoppingListDTO()
            {
                ProductId = Guid.Parse("43075d65-058f-45d8-a584-36fe4533d0d8"),
                ShoppingListId = Guid.Parse("3f100ae0-9d4d-4637-abcb-9aa89435f090"),
            };
            var client = _factory.CreateClient();
            
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWxpdmVsaSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiYWxpdmVsaSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlVzZXIiLCJleHAiOjE2Nzk1MDYwNzMsImlzcyI6ImxvY2FsaG9zdCIsImF1ZCI6ImxvY2FsaG9zdCJ9.ptPSTEmPvzctR-an0pjU8HlUQ20naSHBL75VbPfkG7A");

            var httpContent=new StringContent(JsonConvert.SerializeObject(list), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/addtolist", httpContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task delete_addtolist_test()
        {
          
            
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYXRhbGF5eW9sdWMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImF0YWxheXlvbHVjIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2Nzk3NjQ2NDIsImlzcyI6ImxvY2FsaG9zdCIsImF1ZCI6ImxvY2FsaG9zdCJ9.qG8Xz1fXZHAN89nWbOkBAG2Az9gRO3i491yyUe8ySPE");
            var response = await client.DeleteAsync("/api/AddToList/DeleteProductForShoppingList?shoppingId=3f100ae0-9d4d-4637-abcb-9aa89435f090&productId=5435d5f7-175c-4882-af32-1d860da215e7");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
