using _.UniveraHiringChallengeEntity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Abstractions
{
    public interface IProductForCategoryService
    {
        Task AddCategoryToProduct(Guid productId, AddCategoryToProductDTO addCategoryToProductDTO);
        Task<List<CategoryDTO>> GetCategory(Guid productId);
    }
}
