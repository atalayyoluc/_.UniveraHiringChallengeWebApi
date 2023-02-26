using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.DTOs
{
    public class AddShoppingDTO
    {
        public string ShoppingName { get; set; }
        public string ShoppingDescription { get; set; }
        public Guid UserId { get; set; }
    


    }
}
