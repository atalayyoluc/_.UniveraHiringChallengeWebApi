using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.DTOs
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImgUrl { get; set; }
            
        public Guid Category1Id { get; set; }
        public Guid Category2Id { get; set; }
    }
}
