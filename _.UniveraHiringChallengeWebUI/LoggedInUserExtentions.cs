using _.UniveraHiringChallengeWebUI.Entities.Context;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace _.UniveraHiringChallengeWebUI
{
    public static class LoggedInUserExtentions
    {
        public static Guid GetLoggedInUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Guid.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        public static string GetLoggedInUserEmail(this ClaimsPrincipal claimsPrincipal)
        {

            return claimsPrincipal.FindFirstValue(ClaimTypes.Email);
        }
        public static string GetLogedInUserToken(this ClaimsPrincipal claimsPrincipal)
        {
           var user= Guid.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));
            AppDbContext dbContext = new AppDbContext();
            var users = dbContext.Users.Find(user);
            return users.UserToken;
        }
    }
}
