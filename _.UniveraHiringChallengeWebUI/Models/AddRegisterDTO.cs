namespace _.UniveraHiringChallengeWebUI.Models
{
    public class AddRegisterDTO
    {
        public string userName { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string password { get; set; }
        public string confrimPassword { get; set; }
        public Guid countryId { get; set; }
    }
}
