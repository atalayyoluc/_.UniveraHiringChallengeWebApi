﻿using _.UniveraHiringChallengeEntity.DTOs;
using _.UniveraHiringChallengeEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeBusines.Services.Abstractions
{
    public interface ICategoryService
    {
        Task AddCategory(CreateCategoryDTO category);
        Task<List<Category>> GetListCategory();
        Task UpdateCategory(Guid categoryId,CreateCategoryDTO createCategoryDTO);
        Task DeleteCategory(Guid categoryId);
        Task<Category> GetCategoryByGuid(Guid categoryId);
        Task<List<Product>> GetProductByCategory(Guid categoryId);
    }
}
