using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeEntity.DTOs
{
    public class ListProductDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImgUrl { get; set; }
        public List<CategoryDTO> Category { get; set; }

    }
}
