using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeData.UnitOfWorks.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _.UniveraHiringChallengeWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingService shoppingService;

        public ShoppingController(IShoppingService shoppingService)
        {
            this.shoppingService = shoppingService;
        }
        [HttpGet]
        [Route("{userId:Guid}")]
        public async Task<IActionResult> ListShopping(Guid userId)
        {
            var shopping = await shoppingService.GetListByUser(userId);
            return Ok(shopping);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShopping([FromBody]AddShoppingDTO shoppingDTO)
        {
            await shoppingService.CreateShopping(shoppingDTO);
            return Ok();
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllShopping()
        {
            var shopping = await shoppingService.GetAllShopping();
            return Ok(shopping);
        }
        [HttpGet]
        [Route("[action]/{userId:Guid}")]
        public async Task<IActionResult> ComplatedOrders(Guid userId)
        {
            var shopping=await shoppingService.GetComplatedShoppingByUser(userId);
            return Ok(shopping);
        }
        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> AllComplatedOrder()
        {
            var shopping = await shoppingService.GetAllComplatedShopping();
            return Ok(shopping);
        }
        [HttpPut]
        [Route("[action]/{shoppingId:Guid}")]
        
        public async Task<IActionResult> ComplateOrder(Guid shoppingId)
        {
        await shoppingService.UpdateShopping(shoppingId);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{shoppingId:Guid}")]
        public async Task<IActionResult> OrderDetails(Guid shoppingId)
        {
            var details=await shoppingService.GetProductByShopping(shoppingId);
            return Ok(details);
        }

    }
}
