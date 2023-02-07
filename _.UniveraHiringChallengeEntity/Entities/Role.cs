using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.Entities
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; } = Guid.NewGuid();
        public string RoleName { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
