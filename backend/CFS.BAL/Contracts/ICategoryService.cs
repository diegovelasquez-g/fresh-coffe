using CFS.DAL.Models;

namespace CFS.BAL.Contracts;

public interface ICategoryService
{
    Task<bool> CreateCategoryAsync(Category category);
    Task<bool> UpdateCategoryAsync(int categoryId,Category category);
    Task<bool> ChangeCategoryStatus(int categoryId);
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<List<Category>> GetAllCategoriesAsync();

}