using _.UniveraHiringChallengeBusines.Services.Abstractions;
using _.UniveraHiringChallengeEntity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _.UniveraHiringChallengeWebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDTO)
        {
            await categoryService.AddCategory(categoryDTO);
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetListCategory()
        {
           var categories=await categoryService.GetListCategory();
            return Ok(categories);
        }
        [HttpPut]
        [Route("{categoryId:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, CreateCategoryDTO createCategoryDTO)
        {
            await categoryService.UpdateCategory(categoryId,createCategoryDTO);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(Guid categoryID)
        {
            await categoryService.DeleteCategory(categoryID);
            return Ok();
        }
        [HttpGet]
        [Route("{categoryId:Guid}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetByCategory(Guid categoryId)
        {
            var categories = await categoryService.GetCategoryByGuid(categoryId);
            return Ok(categories);
        }
        [HttpGet]

        [Route("[action]/{categoryId:Guid}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetProductByCategory(Guid categoryId)
        {
            var categories = await categoryService.GetProductByCategory(categoryId);
            return Ok(categories);
        }
    }
}
