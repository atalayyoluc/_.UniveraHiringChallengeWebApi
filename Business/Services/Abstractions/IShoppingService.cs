using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Abstractions
{
    public interface IShoppingService
    {
        Task<List<ListShoppingDTO>> GetListByUser(Guid userId);
        Task CreateShopping(AddShoppingDTO shoppingDTO);
        Task<List<ListAllShopping>> GetAllShopping();
        Task<List<ListAllShopping>> GetComplatedShoppingByUser(Guid userId);
        Task<List<ListAllShopping>> GetAllComplatedShopping();
        Task UpdateShopping(Guid shoppingId);
        Task<List<Product>> GetProductByShopping(Guid shoppingId);
    }
}
