using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.Entities
{
    public class Country
    {
        [Key]
        public Guid CountryId { get; set; } = Guid.NewGuid();
        public string CountryName { get; set; }
        public string CountryImageUrl { get; set; }
        public List<User> Users { get; set; }
    }
}
