using CFS.BAL.Contracts;
using CFS.DAL.Contracts;
using CFS.DAL.Models;

namespace CFS.BAL.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CreateCategoryAsync(Category category)
    {
        category.CreateDate = DateTime.Now;
        await _unitOfWork.CategoryRepository.CreateAsync(category);
        var isSuccess = await _unitOfWork.SaveChangesAsync();
        return isSuccess;
    }

    public async Task<bool> UpdateCategoryAsync(int categoryId, Category category)
    {
        var existingCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
        if(existingCategory == null)
            return false;

        if(!string.IsNullOrEmpty(category.CategoryName))
            existingCategory.CategoryName = category.CategoryName;

        if (!string.IsNullOrEmpty(category.Description))
            existingCategory.Description = category.Description;

        existingCategory.UpdateBy = category.UpdateBy;
        existingCategory.UpdateDate = DateTime.Now;

        _unitOfWork.CategoryRepository.UpdateAsync(existingCategory);
        var isSuccess = await _unitOfWork.SaveChangesAsync();
        return isSuccess;
    }

    public async Task<bool> ChangeCategoryStatus(int categoryId)
    {
        var existingCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
        if (existingCategory == null)
            return false;
        
        existingCategory.IsActive = !existingCategory.IsActive;
        existingCategory.UpdateDate = DateTime.Now;

        _unitOfWork.CategoryRepository.UpdateAsync(existingCategory);
        var isSuccess = await _unitOfWork.SaveChangesAsync();
        return isSuccess;

    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
        return category;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
        return categories.ToList();
    }
}