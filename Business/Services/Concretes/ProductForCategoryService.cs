using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeData.UnitOfWorks.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Concretes
{
    public class ProductForCategoryService : IProductForCategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductForCategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddCategoryToProduct(Guid productId ,AddCategoryToProductDTO addCategoryToProductDTO)
        {

           
            Guid[] guids = { Guid.Parse(addCategoryToProductDTO.Category1Id), Guid.Parse(addCategoryToProductDTO.Category2Id) };
            for(int i=0; i<guids.Length; i++) {

                ProductCategory productCategories = new ProductCategory()
                {
                    ProductId=productId,
                    CategoryId = guids[i]
                };
                await unitOfWork.GetRepository<ProductCategory>().AddAsync(productCategories);
                await unitOfWork.SaveAsync();
                }        
                }

        public async Task<List<CategoryDTO>> GetCategory(Guid productId)
        {
           var categories= await unitOfWork.GetRepository<ProductCategory>().GetAllAsync(x => x.ProductId == productId, x => x.Category);
            List<CategoryDTO> category = new List<CategoryDTO>();
            foreach (var item in categories) {
                category.Add(new CategoryDTO()
                {
                    CategoryId= item.CategoryId,
                    CategoryName =item.Category.CategoryName,
                    
                    
                }); }
            return category;
        }
    }
    
}
