using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.DTOs
{
    public class ListAllShopping
    {
        public Guid ShoppingId { get; set; }
        public string ShoppingName { get; set; }
        public string ShoppingDescription { get; set; }
        public DateTime ShoppingDate { get; set; }
        public string FullName { get; set; }
        public DateTime? ComplatedDate { get; set; }
        public bool Iscomplated { get; set; }
    }
}
