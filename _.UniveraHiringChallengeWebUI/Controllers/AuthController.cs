using _.UniveraHiringChallengeWebUI.Entities;
using _.UniveraHiringChallengeWebUI.Entities.Context;
using _.UniveraHiringChallengeWebUI.Models;
using _.UniveraHiringChallengeWebUI.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace _.UniveraHiringChallengeWebUI.Controllers
{
    public class AuthController : Controller
    {
        #region Defines
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly HttpClient httpClient;
		private readonly string Url = "http://localhost:12923/api/Auth/";
        private readonly string CountryUrl = "http://localhost:12923/api/Country";
        private readonly AppDbContext context;
        private readonly RoleManager<AppRole> roleManager;
        #endregion

        #region Constructor
        public AuthController(HttpClient httpClient, AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            this.httpClient = httpClient;
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        #endregion

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginView)
        {
            var user = await userManager.FindByNameAsync(loginView.userName);
            var result = await signInManager.PasswordSignInAsync(user, loginView.password, false, false);
            if (result.Succeeded) {
                
                if (loginView.userToken != null)
                {
                    loginView.userToken = user.UserToken;
                }
                else
                {
                    loginView.userToken = null;
                }
                var response = await httpClient.PostAsJsonAsync(Url, loginView);
                if (response.IsSuccessStatusCode)
                {
                    var user1 = await response.Content.ReadFromJsonAsync<UserToken>();
                    user.UserToken = user1.userToken;
                    context.Update<AppUser>(user);
                    context.SaveChanges();
                   
                    return RedirectToAction("Index","Home");
                }
            }
                return View();
        }

        public async Task<IActionResult> Register() 
        {
            var countryies = await httpClient.GetFromJsonAsync<List<CountryViewModel>>(CountryUrl);

            return View(new RegisterViewModel { Countries=countryies});
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerView)
        {
           if (registerView.password == registerView.confirmPassword)
            {
                var response = await httpClient.PostAsJsonAsync(Url+"Register", registerView);
            if (response.IsSuccessStatusCode)
            {
                
                    var user = await response.Content.ReadFromJsonAsync<AddAppUser>();
                    AppUser user1 = new AppUser()
                    {
                        UserName = user.userName,
                        UserFirstName = user.userFirstName,
                        UserLastName = user.userLastName,
                        UserToken = user.userToken,
                        CountryImgUrl = user.countryImgUrl,
                        Id = user.userId
                    };
                    var result = await userManager.CreateAsync(user1, registerView.password);
                    if (result.Succeeded)
                    {
                    var findRole = await roleManager.FindByIdAsync(user.roleId.ToString());
                    var role= await userManager.AddToRoleAsync(user1, findRole.Name.ToString());
                        return RedirectToAction("Login");
                    }
                }
            }
            var countryies = await httpClient.GetFromJsonAsync<List<CountryViewModel>>(CountryUrl);

            return View(new RegisterViewModel { Countries = countryies });
          
        }

        public IActionResult Logout()
        {

            return View();
        }

    }
}
