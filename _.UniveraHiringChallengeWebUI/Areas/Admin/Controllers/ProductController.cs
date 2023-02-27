
using _.UniveraHiringChallengeWebUI.Areas.Admin.Models;
using _.UniveraHiringChallengeWebUI.Entities.Context;
using _.UniveraHiringChallengeWebUI.Models;
using _.UniveraHiringChallengeWebUI.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _.UniveraHiringChallengeWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductController : Controller
    {

        #region Defines
        private readonly IUnitOfWork unitOfWork;
        private readonly ClaimsPrincipal user;

       
  

        private readonly string Url = "Product";
        private readonly string CategoryUrl = "Category";
        #endregion
        #region Constructor
        public ProductController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            
            this.unitOfWork = unitOfWork;
            user = httpContextAccessor.HttpContext.User;
        }
        #endregion
      

        public async Task<IActionResult> Index()
        {

            var product = await unitOfWork.GetWebConnect<ProductViewModel>().GetListAsync(Url,user.GetLogedInUserToken());
         
            
            return View(product);
        }
        public async Task<IActionResult> Add()
        {

            
            var categories = await unitOfWork.GetWebConnect<CategoryViewModel>().GetListAsync(CategoryUrl,user.GetLogedInUserToken());
            return View(new AddProductViewModel { Categories = categories });
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductViewModel)
        {
           await unitOfWork.GetWebConnect<AddProductViewModel>().PostAsync(Url,addProductViewModel,user.GetLogedInUserToken());
           
                return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Guid productId)
        {
            string Token = user.GetLogedInUserToken();
            var categories = await unitOfWork.GetWebConnect<CategoryViewModel>().GetListAsync(CategoryUrl,Token);
            var productDTO = await unitOfWork.GetWebConnect<ProductViewModel>().GetAsync(Url, productId,Token);
            UpdateProductViewModel updateProductDTO = new UpdateProductViewModel()
            {
                productId = productDTO.productId,
                productName = productDTO.productName,
                productDescription = productDTO.productDescription,
                productImgUrl = productDTO.productImgUrl,
                Categories = categories
            };

            return View(updateProductDTO);
        }


    }
}
