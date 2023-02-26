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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductForCategoryService productForCategoryService;
        public ProductService(IUnitOfWork unitOfWork, IProductForCategoryService productForCategoryService)
        {
            this.unitOfWork = unitOfWork;
            this.productForCategoryService = productForCategoryService;
        }

        public async Task CreateProduct(CreateProductDTO createProductDTO)
        {
            Product product=new Product()
            {
                ProductName= createProductDTO.ProductName,
                ProductDescription= createProductDTO.ProductDescription,
                ProductImgUrl= createProductDTO.ProductImgUrl,
            };
            AddCategoryToProductDTO addCategoryToProductDTO = new AddCategoryToProductDTO()
            {
                Category1Id = Convert.ToString(createProductDTO.Category1Id),
                Category2Id = Convert.ToString(createProductDTO.Category2Id),
                
            
                
            };
           
            await unitOfWork.GetRepository<Product>().AddAsync(product);
            
            await unitOfWork.SaveAsync();
            await productForCategoryService.AddCategoryToProduct(product.ProductId,addCategoryToProductDTO);
        }

        public async Task DeleteProduct(Guid productID)
        {
           var product= await unitOfWork.GetRepository<Product>().GetByGuidAsync(productID);
            await unitOfWork.GetRepository<Product>().DeleteAsync(product);
            await unitOfWork.SaveAsync();
        }

        public async Task<ListProductDTO> GetProduct(Guid productID)
        {
           var product=await unitOfWork.GetRepository<Product>().GetByGuidAsync(productID);
            ListProductDTO listProductDTO= new ListProductDTO()
            {
                ProductId =product.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductImgUrl = product.ProductImgUrl,
                Category = await productForCategoryService.GetCategory(product.ProductId),
            };
            return listProductDTO;
        }

        public async Task<List<ListProductDTO>> ListProduct()
        {
            var product = await unitOfWork.GetRepository<Product>().GetAllAsync();
            List<ListProductDTO> listProductDTO = new List<ListProductDTO>();

            foreach (var item in product)
            {
                listProductDTO.Add(new ListProductDTO()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductDescription = item.ProductDescription,
                    ProductImgUrl = item.ProductImgUrl,
                    Category = await productForCategoryService.GetCategory(item.ProductId),
        
                }) ;
            }
            return listProductDTO; 
        }

        public async Task UpdateProduct(Guid productId, UpdateProductDTO updateProductDTO)
        {
           var product= await unitOfWork.GetRepository<Product>().GetByGuidAsync(productId);
            product.ProductName= updateProductDTO.ProductName;
            await unitOfWork.SaveAsync();
        }
    }
}
