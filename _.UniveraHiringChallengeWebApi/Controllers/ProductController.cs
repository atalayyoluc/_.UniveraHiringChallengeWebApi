using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _.UniveraHiringChallengeWebApi.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await productService.CreateProduct(createProductDTO);
                return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            await productService.DeleteProduct(productId);
            return Ok();
        }
        [HttpGet]

        public async Task<IActionResult> ListProduct()
        {
           var item= await productService.ListProduct();
            return Ok(item);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(Guid productId,UpdateProductDTO updateProduct)
        {
            await productService.UpdateProduct(productId, updateProduct);
            return Ok();
        }
        [HttpGet]
        [Route("{productId:Guid}")]
        public async Task<IActionResult>GetByProduct(Guid productId)
        {
           var product= await productService.GetProduct(productId);
            return Ok(product);
        }
    }
}
