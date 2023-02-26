using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.DTOs
{
    public class RegisterDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string CountryImgUrl { get; set; }
        public string? UserToken { get; set; }
        public Guid RoleId { get; set; }
    }
}
