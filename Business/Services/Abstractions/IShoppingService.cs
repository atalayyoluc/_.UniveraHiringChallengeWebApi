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
        Task CreateShopping(AddShoppingDTO shoppingDTO);
        Task<List<ListAllShopping>> GetAllComplatedShopping();
        Task<List<ListAllShopping>> GetAllShopping();
        Task<List<ListAllShopping>> GetComplatedShoppingByUser(Guid userId);
        Task<List<ListShoppingDTO>> GetListByUser(Guid userId);
        Task<List<Product>> GetProductByShopping(Guid shoppingId);
        Task UpdateShopping(Guid shoppingId);
        Task<List<ListAllShopping>> AllShopping();
        Task<List<ListAllShopping>> AllActiveShopping();
    }
}
