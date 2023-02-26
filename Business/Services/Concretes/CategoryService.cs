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
    public class CategoryService : ICategoryService
    {
                  private readonly IUnitOfWork unitOfWork;
       

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public async Task AddCategory(CreateCategoryDTO category)
        {
           if(category.CategoryName!=null)
            {
                Category category1= new Category()
                {
                    CategoryName = category.CategoryName,
                    
                };
                await unitOfWork.GetRepository<Category>().AddAsync(category1);
                await unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteCategory(Guid categoryId)
        {

            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            await unitOfWork.GetRepository<Category>().DeleteAsync(category);
            await unitOfWork.SaveAsync();
        }

        public async Task<Category> GetCategoryByGuid(Guid categoryId)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            return category;

        }

        public async Task<List<Category>> GetListCategory()
        {
          return await unitOfWork.GetRepository<Category>().GetAllAsync();
            
        }

        public async Task<List<Product>> GetProductByCategory(Guid categoryId)
        {
            var product = await unitOfWork.GetRepository<ProductCategory>().GetAllAsync(x=>x.CategoryId==categoryId,x=>x.Product);
            List<Product> product1 = new List<Product>();

                foreach(var item in product)
                { 
                product1.Add(new Product() {

                ProductId= item.Product.ProductId,
                ProductName= item.Product.ProductName,
                ProductImgUrl= item.Product.ProductImgUrl,
                ProductDescription= item.Product.ProductDescription,
                

                });
            }
            return product1;
        }

        public async Task UpdateCategory(Guid categoryId, CreateCategoryDTO createCategoryDTO)
        {
          var category=await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryId);
            category.CategoryName=createCategoryDTO.CategoryName;
            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();
        }
    }
}
