using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.Entities
{
    public class ShoppingListProduct
    {
        public Guid ShoppingListId { get; set; }

        public ShoppingList ShoppingList { set; get; }

        public Guid ProductId { set; get; }
        public Product Product { set; get; }
    }
}
