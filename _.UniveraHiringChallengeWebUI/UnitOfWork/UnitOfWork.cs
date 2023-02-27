using _.UniveraHiringChallengeWebUI.Repositories;

namespace _.UniveraHiringChallengeWebUI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IWebConnect<T> GetWebConnect<T>() where T : class, new()
        {
            return new WebConnect<T>();
        }
    }
}
