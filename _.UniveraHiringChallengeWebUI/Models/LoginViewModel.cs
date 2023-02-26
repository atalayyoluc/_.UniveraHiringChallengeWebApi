using System.ComponentModel.DataAnnotations;

namespace _.UniveraHiringChallengeWebUI.Models
{
	public class LoginViewModel
	{
		[Required]
		public string userName { get; set; }
		public string password { get; set; }
		public string? userToken { get; set; }
	}
}
