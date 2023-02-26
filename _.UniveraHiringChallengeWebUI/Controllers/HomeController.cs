using _.UniveraHiringChallengeWebUI.Areas.Admin.Models;
using _.UniveraHiringChallengeWebUI.Entities.Context;
using _.UniveraHiringChallengeWebUI.Models;
using _.UniveraHiringChallengeWebUI.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Security.Claims;

namespace _.UniveraHiringChallengeWebUI.Controllers
{
    [Authorize(Roles ="User,Admin")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ClaimsPrincipal user;
        public HomeController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            user = httpContextAccessor.HttpContext.User;
        }



        public async Task<IActionResult> Index()
        {
          
            var list = await unitOfWork.GetWebConnect<ShoppingListViewModel>().GetListByUserAsync("Shopping",user.GetLoggedInUserId(),user.GetLogedInUserToken());
            
            return View(list);
        }
        public async Task<IActionResult> Shopping()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Shopping(AddShopping shopping)
        {
            shopping.userId =user.GetLoggedInUserId();
        var response= await unitOfWork.GetWebConnect<AddShopping>().PostAsync("Shopping", shopping,user.GetLogedInUserToken());
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
                               
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid shoppingId,Guid productId)
        {

        var response= await unitOfWork.GetWebConnect<ProductViewModel>().Delete("AddToList/DeleteProductForShoppingList", shoppingId, productId, user.GetLogedInUserToken());
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Shopping");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]   
        public async Task<IActionResult> AddProductToList(Guid shoppingId,Guid?categoryId)
        {
            string Token = user.GetLogedInUserToken();
            var category = await unitOfWork.GetWebConnect<CategoryViewModel>().GetListAsync("Category",Token);
            ViewBag.category=category;
            TempData["shoppingId"] = shoppingId;
            if (categoryId != null)
            {
                var product = await unitOfWork.GetWebConnect<ProductViewModel>().GetListAsync("Category/GetProductByCategory/"+categoryId, Token);
                ViewBag.product = product;
                return View();
            }
            else
            {
                var product = await unitOfWork.GetWebConnect<ProductViewModel>().GetListAsync("Product", Token);
                ViewBag.product = product;
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetails(Guid shoppingId)
        {

            var product = await unitOfWork.GetWebConnect<ProductViewModel>().GetListAsync("Shopping/OrderDetails/" + shoppingId, user.GetLogedInUserToken());
            ViewBag.shoppingId = shoppingId;
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToList(AddProductForShoppingListViewModel addProductForShoppingListDTO)
        {
            string Token = user.GetLogedInUserToken();
            var category = await unitOfWork.GetWebConnect<CategoryViewModel>().GetListAsync("Category", Token);
            ViewBag.category = category;
            var a = await unitOfWork.GetWebConnect<AddProductForShoppingListViewModel>().PostAsync("AddToList", addProductForShoppingListDTO,Token);
          

            
            var product = await unitOfWork.GetWebConnect<ProductViewModel>().GetListAsync("Product", Token);
            ViewBag.product = product;
            TempData["shoppingId"] =addProductForShoppingListDTO.shoppingListId;

            return View();
         }

        [HttpGet]
        public async Task<IActionResult> CompletedOrders()
        {

            var shopping = await unitOfWork.GetWebConnect<ShoppingListViewModel>().GetListByUserAsync("Shopping/ComplatedOrders", user.GetLoggedInUserId(), user.GetLogedInUserToken());
            return View(shopping);
        }
        public async Task<IActionResult> ComplateShopping(Guid shoppingId)
        {
            var response = await unitOfWork.GetWebConnect<ShoppingListViewModel>().PutAsync("Shopping/ComplateOrder", shoppingId,user.GetLogedInUserToken());
            return RedirectToAction("Index", "Home");
        }



    }
}
