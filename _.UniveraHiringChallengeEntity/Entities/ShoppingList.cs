using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.Entities
{
    public class ShoppingList
    {
        [Key]
        public Guid ShoppingId { get; set; } = Guid.NewGuid();
        public string ShoppingName { get; set; }
        public string ShoppingDescription { get; set; }
        public DateTime ShoppingDate { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool IsShoppingComplate { get; set; }=false;
        public DateTime? ComplateDate { get; set; }
        public List<ShoppingListProduct> ShoppingListProducts { get; set; }
    }
}
