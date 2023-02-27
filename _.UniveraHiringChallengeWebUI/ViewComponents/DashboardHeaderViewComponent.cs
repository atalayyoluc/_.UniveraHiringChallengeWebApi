using _.UniveraHiringChallengeWebUI.Entities.Context;
using _.UniveraHiringChallengeWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _.UniveraHiringChallengeWebUI.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly ClaimsPrincipal user;

        public DashboardHeaderViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            user = httpContextAccessor.HttpContext.User;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppDbContext context = new AppDbContext();
            var users = user.GetLoggedInUserId();
            var activeUser = await context.Users.FindAsync(users);
            UserDashBoardHeaderModel userDashBoardHeader = new UserDashBoardHeaderModel()
            {
                ImgUrl = activeUser.CountryImgUrl,
                UserName = activeUser.UserFirstName + activeUser.UserLastName
            };


            return View(userDashBoardHeader);
        }
    }
}

