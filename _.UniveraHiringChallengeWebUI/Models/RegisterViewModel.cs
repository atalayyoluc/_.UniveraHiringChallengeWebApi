namespace _.UniveraHiringChallengeWebUI.Models
{
    public class RegisterViewModel
    {
        public string userName { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public Guid countryId { get; set; }
        public IList<CountryViewModel> Countries { get; set; }
    }
}
