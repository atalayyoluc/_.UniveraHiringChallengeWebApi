using _.UniveraHiringChallengeWebUI.Entities.Context;
using _.UniveraHiringChallengeWebUI.Models;
using _.UniveraHiringChallengeWebUI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _.UniveraHiringChallengeWebUI.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class ShoppingController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ClaimsPrincipal user;
        public ShoppingController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            user = httpContextAccessor.HttpContext.User;
        }
        public string UserToken()
        {
            AppDbContext dbContext = new AppDbContext();
            var users = dbContext.Users.Find(user.GetLoggedInUserId());
            return users.UserToken;
        }

        public async Task<IActionResult> Index()
        {
            string Token = UserToken();

          var List= await unitOfWork.GetWebConnect<ShoppingListViewModel>().GetListAsync("Shopping/AllComplatedOrder",Token);
            return View(List);
        }
    }
}
