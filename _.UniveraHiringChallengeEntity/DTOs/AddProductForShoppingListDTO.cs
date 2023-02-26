using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.DTOs
{
    public class AddProductForShoppingListDTO
    {
        public Guid ShoppingListId { get; set; }
        public Guid ProductId { get; set; }
    }
}
