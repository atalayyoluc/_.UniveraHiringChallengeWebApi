using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImgUrl { get; set; }
        public List<ProductCategory> ProductCategory { get; set; }
        public List<ShoppingList> ShoppingLists { get; set; }

    }
}
