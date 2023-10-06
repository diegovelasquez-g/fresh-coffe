using CFS.BAL.Contracts;
using CFS.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CFS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var result = await _categoryService.GetCategoryByIdAsync(categoryId);
            if(result != null)
                return Ok(result);
            return BadRequest("No se encontró la categoria.");
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            var result = await _categoryService.CreateCategoryAsync(category);
            if(result)
                return Ok("Categoria creada con éxito.");
            return BadRequest("No se pudo crear la categoria");
        }

        [HttpPut]
        [Route("ChangeCategory/{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, Category category)
        {
            var result = await _categoryService.UpdateCategoryAsync(categoryId, category);
            if(result)
                return Ok("Categoria actualizada con éxito.");
            return BadRequest("Ha ocurrido un error, no se pudo actualizar la categoria.");
        }

        [HttpDelete]
        [Route("ChangeCategoryStatus/{categoryId}")]
        public async Task<IActionResult> ChangeCategoryStatus(int categoryId)
        {
            var result = await _categoryService.ChangeCategoryStatus(categoryId);
            if(result)
                return Ok("Se ha cambiado el estado de la categoria.");
            return BadRequest("Ha ocurrido un error, no se pudo cambiar el estado de la categoria.");
        }
    }
}
