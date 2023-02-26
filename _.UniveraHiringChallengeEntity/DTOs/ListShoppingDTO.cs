using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.DTOs
{
    public class ListShoppingDTO
    {
        public Guid ShoppingId { get; set; }
        public string ShoppingName { get; set; }
        public string ShoppingDescription { get; set; }
        public DateTime ShoppingDate { get; set; }
       
    }
}
