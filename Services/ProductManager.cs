using ConsoleApp2.Entity;
using ConsoleApp2.Interface;
using ConsoleApp2.Models;

using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Manager
{
    public class ProductManager : IRepositary<Product> 
    {
        private readonly EntityContext _dbContext;

        public ProductManager(EntityContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<ResultModel> AddAsync(Product product)
        {
            try
            {
                await _dbContext.AddAsync(product);

                await _dbContext.SaveChangesAsync();

                return new ResultModel { Success = true, Message = "Product added successfully" };
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = ex.Message };
            }
        }

        public async Task<ResultModel> DeleteAsync(int productId)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(productId);
                if (product == null)
                {
                    return new ResultModel { Success = false, Message = "Product not found" };
                }

                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();

                return new ResultModel { Success = true, Message = "Product Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = ex.Message };
            }
        }

        public async Task<ResultModel> UpdateAsync(Product updatedProduct)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(updatedProduct.Id);
                if(product == null) return new ResultModel { Success = false, Message = "Product not found" };

                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                product.Description = updatedProduct.Description;
                product.Category = updatedProduct.Category;

                _dbContext.Products.Update(product);
                await _dbContext.SaveChangesAsync();
                return new ResultModel { Success = true, Message = "Product Updated Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = ex.Message };
            }
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(productId);
                if (product == null) return null;
                return product;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var products = await _dbContext.Products.ToListAsync();
                if (!products.Any()) return null;
                return products;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
