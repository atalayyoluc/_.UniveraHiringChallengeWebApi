using _.UniveraHiringChallengeWebUI.Areas.Admin.Models;
using System.Net.Http;
using System;
using System.Security.Claims;
using _.UniveraHiringChallengeWebUI.Entities.Context;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Newtonsoft.Json;
using System.Text;

namespace _.UniveraHiringChallengeWebUI.Repositories
{
    public class WebConnect<T> : IWebConnect<T> where T : class, new()
    {
        HttpClient client = new HttpClient();
        private readonly string BaseURL = "http://localhost:12923/api/";
        private readonly ClaimsPrincipal user;


        public async Task<HttpResponseMessage> Delete(string Url, Guid shoppingId, Guid productId, string Token)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{BaseURL}{Url}?shoppingId={shoppingId}&productId={productId}"),
                Headers =
                {
                    {"Authorization","Bearer"+Token }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                return response;
            }
        }


        public async Task<List<T>> GetListAsync(string Url, string Token)
        {

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(BaseURL + Url),
                Headers =
                    {

                    {"Authorization" ,"Bearer "+
                 Token}
                    }


            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadFromJsonAsync<List<T>>().Result;
                return body;
            }


        }

        public async Task<HttpResponseMessage> PostAsync(string Url, T entity, string Token)
        {
            var response = client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            var json = await client.PostAsJsonAsync(BaseURL + Url, entity);
            return json;
        }

        public async Task<T> GetAsync(string Url, Guid productId, string Token)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(BaseURL + Url + "/" + productId),
                Headers =
                {

                    {"Authorization" ,"Bearer "+Token}
                                    }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadFromJsonAsync<T>().Result;
                return body;
            }
        }

        public async Task<List<T>> GetListByUserAsync(string Url, Guid UserId, string Token)
        {

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(BaseURL + Url + "/" + UserId),
                Headers =
                {

                    {"Authorization" ,"Bearer "+
                 Token}
                                    }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadFromJsonAsync<List<T>>().Result;
                return body;
            }
        }


        public async Task<HttpResponseMessage> PutAsync(string Url, Guid shoppingId, string Token)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(BaseURL + Url + "/" + shoppingId),
                Headers =
                {

                    {"Authorization" ,"Bearer "+
                 Token}
                                    }
            };
            using (var response = await client.SendAsync(request))
            {
                return response;

            }
        }
        public async Task<HttpResponseMessage> PutAsync(string Url, Guid id, string Token, T entity)
        {
            var httpcontext = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(BaseURL + Url + "/" + id),
                Content = httpcontext,
                Headers =
                {
                    {
                        "Authorization", "Bearer" + Token
                    }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                return response;
            }
        }
    }



}


