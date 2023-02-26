using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeBusines.Services.Concretes;
using _.UniveraHiringChallengeEntity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _.UniveraHiringChallengeWebApi.Controllers
{
    [Authorize(Roles ="Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddToListController : ControllerBase
    {
        readonly IShoppingListService shoppingList;

        public AddToListController(IShoppingListService shoppingList)
        {
            this.shoppingList = shoppingList;
        }

        [HttpPost]
        public async Task<IActionResult> ShoppingListForProduct(AddProductForShoppingListDTO addProductForShoppingListDTO)
        {
            await shoppingList.AddProductForShoppingList(addProductForShoppingListDTO);            
            return Ok();
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProductForShoppingList(Guid shoppingId,Guid productId)
        {
            await shoppingList.DeleteProductForShoppingList(shoppingId, productId);
            return Ok();
        }
    }
}
