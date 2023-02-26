using _.UniveraHiringChallengeWebUI.APIContent;
using _.UniveraHiringChallengeWebUI.Areas.Admin.Models;
using _.UniveraHiringChallengeWebUI.Entities.Context;
using _.UniveraHiringChallengeWebUI.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _.UniveraHiringChallengeWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        #region Defines
        private readonly IUnitOfWork unitOfWork;
        private readonly ClaimsPrincipal user;
        private readonly string Url = "Category";
       
        
        
        #endregion
        #region Constructor
        public CategoryController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
       
            this.unitOfWork = unitOfWork;
            user = httpContextAccessor.HttpContext.User;
        }
        #endregion
     



        public async Task<IActionResult> Index()
        {
          
            var body = await unitOfWork.GetWebConnect<CategoryViewModel>().GetListAsync(Url,user.GetLogedInUserToken());
            return View(body);
        }


        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDTO category)
        {
            await unitOfWork.GetWebConnect<AddCategoryDTO>().PostAsync(Url, category,user.GetLogedInUserToken());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            
            var category = await unitOfWork.GetWebConnect<CategoryViewModel>().GetAsync(Url, categoryId,user.GetLogedInUserToken());
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryViewModel categoryViewModel)
        {

   
            var category = new AddCategoryDTO()
            {
                categoryName = categoryViewModel.categoryName
            };
           var respronse= await unitOfWork.GetWebConnect<AddCategoryDTO>().PutAsync(Url,categoryViewModel.categoryId,user.GetLogedInUserToken(),category);
            if (respronse.IsSuccessStatusCode)
            {
                return Redirect("Index");
            }
            var categoryId = await unitOfWork.GetWebConnect<CategoryViewModel>().GetAsync(Url, categoryViewModel.categoryId,user.GetLogedInUserToken());
            return View(categoryId);
        }
       
    }
}
