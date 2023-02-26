using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeData.UnitOfWorks.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Concretes
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IUnitOfWork unitOfWork;

        public ShoppingListService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddProductForShoppingList(AddProductForShoppingListDTO addProductForShoppingListDTO)
        {
            ShoppingListProduct shoppingList = new ShoppingListProduct();
            shoppingList.ProductId =addProductForShoppingListDTO.ProductId;
            shoppingList.ShoppingListId = addProductForShoppingListDTO.ShoppingListId;
            await unitOfWork.GetRepository<ShoppingListProduct>().AddAsync(shoppingList);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteProductForShoppingList(Guid shoppingId, Guid productId)
        {
            var shopping=await unitOfWork.GetRepository<ShoppingListProduct>().GetAsync(x=>x.ShoppingListId==shoppingId&&x.ProductId==productId);
            unitOfWork.GetRepository<ShoppingListProduct>().DeleteAsync(shopping);
            unitOfWork.SaveAsync();
        }
    }
}
