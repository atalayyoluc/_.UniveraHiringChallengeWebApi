using Microsoft.AspNetCore.Identity;

namespace _.UniveraHiringChallengeWebUI.Entities
{
    public class AppUser:IdentityUser<Guid>
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CountryImgUrl { get; set; }
        public string? UserToken { get; set; } 
    }
}
