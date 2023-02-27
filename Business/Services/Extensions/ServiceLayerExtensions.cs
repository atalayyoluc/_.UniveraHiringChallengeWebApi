using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeBusines.Services.Concretes;
using _.UniveraHiringChallengeData.Repositories.Abstractions;
using _.UniveraHiringChallengeData.Repositories.Concretes;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductForCategoryService, ProductForCategoryService>();
            services.AddScoped<IShoppingService, ShoppingService>();
            services.AddScoped<IShoppingListService, ShoppingListService>();


            return services;
        }
    }
}
