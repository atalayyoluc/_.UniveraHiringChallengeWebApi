using _.UniveraHiringChallengeWebUI.APIContent;

namespace _.UniveraHiringChallengeWebUI.UnitOfWork
{
    public interface IUnitOfWork
    {
       IWebConnect<T> GetWebConnect<T>() where T : class, new();
    }
}
