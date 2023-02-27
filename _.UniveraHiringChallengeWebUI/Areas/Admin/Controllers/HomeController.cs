using _.UniveraHiringChallengeWebUI.Entities.Context;
using _.UniveraHiringChallengeWebUI.Models;
using _.UniveraHiringChallengeWebUI.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using ServiceReference1;
using System.Security.Claims;
using System.Xml;

namespace _.UniveraHiringChallengeWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ClaimsPrincipal user;
        public HomeController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
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
            var shopping = await unitOfWork.GetWebConnect<ListAllShoppingDTO>().GetListAsync("Shopping/GetAllShopping",Token);
            return View(shopping);
        }
        public async Task<IActionResult> Soap()
        {
            var client = new ServiceReference1.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(24322335000),"Ali","Veli",1999);
            var b = response.Body.TCKimlikNoDogrulaResult;
            if (b)
            {
                ViewBag.a = "Doğru";
            }
            else
            {
                ViewBag.a = "Yanlış";
            }
            return View();

        }




    }
}
