using CFS.DAL.Models;

namespace CFS.BAL.Contracts;

public interface IProductService
{
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(int productId, Product product);
    Task<bool> ChangeProductStatus(int productId);
    Task<Product?> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetProductsAsync();
}