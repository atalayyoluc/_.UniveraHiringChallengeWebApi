using _.UniveraHiringChallengeWebUI.Repositories;
using _.UniveraHiringChallengeWebUI.UnitOfWork;

namespace _.UniveraHiringChallengeWebUI
{
    public static class LayerExtensions
    {
        public static IServiceCollection LoadLayerExtension(this IServiceCollection services)
        {

            services.AddScoped(typeof(IWebConnect<>), typeof(WebConnect<>));
            services.AddScoped<IUnitOfWork,UnitOfWork.UnitOfWork>();
            return services;


        }
    }
}
