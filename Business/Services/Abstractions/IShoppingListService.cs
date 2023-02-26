using _.UniveraHiringChallengeEntity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Abstractions
{
    public interface IShoppingListService
    {
        Task AddProductForShoppingList(AddProductForShoppingListDTO addProductForShoppingListDTO);
        Task DeleteProductForShoppingList(Guid shoppingId, Guid productId);
    }
}
