namespace _.UniveraHiringChallengeWebUI.APIContent
{
    public interface IWebConnect<T> where T : class,new()
    {
        Task<List<T>> GetListAsync(string Url,string Token);
        Task<HttpResponseMessage> PostAsync(string Url,T entity, string Token);
        Task<T> GetAsync(string Url,Guid productId, string Token);
        Task<List<T>> GetListByUserAsync(string Url,Guid UserId,string Token);
        Task<HttpResponseMessage> PutAsync(string Url, Guid shoppingId, string Token);
        Task<HttpResponseMessage> Delete(string Url, Guid shoppingId, Guid productId, string Token);
        Task<HttpResponseMessage> PutAsync(string Url, Guid id, string Token, T entity);
    }
}
