using _.UniveraHiringChallengeEntity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Abstractions
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductDTO createProductDTO);
        Task DeleteProduct(Guid productID);
        Task<ListProductDTO> GetProduct(Guid productID);
        Task<List<ListProductDTO>> ListProduct();
        Task UpdateProduct(Guid productId, UpdateProductDTO updateProductDTO);
    }
}
