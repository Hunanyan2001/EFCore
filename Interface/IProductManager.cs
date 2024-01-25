using ConsoleApp2.Models;

namespace ConsoleApp2.Interface
{
    public interface IProductManager
    {
        Task<ResultModel> AddProductAsync(Product product);

        Task<ResultModel> DeleteProductAsync(int productId);

        Task<ResultModel> UpdateProductAsync(Product product);

        Task<Product> GetProductByIdAsync(int productId);

        Task<List<Product>> GetAllProductAsync();
    }
}
