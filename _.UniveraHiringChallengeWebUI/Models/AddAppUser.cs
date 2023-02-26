namespace _.UniveraHiringChallengeWebUI.Models
{
    public class AddAppUser
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string countryImgUrl { get; set; }
        public string? userToken { get; set; }
        public Guid roleId { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
