using ConsoleApp2.Entity;
using ConsoleApp2.Interface;
using ConsoleApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2.Services
{
    public class CategoryManager : IRepositary<Category>
    {
        private readonly EntityContext _dbContext;
        public CategoryManager(EntityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultModel> AddAsync(Category product)
        {
            try
            {
                await _dbContext.Categories.AddAsync(product);

                await _dbContext.SaveChangesAsync();

                return new ResultModel { Success = true, Message = "Category Succsesfuly added" };
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
                var category = await _dbContext.Categories.FindAsync();
                if(category == null)
                {
                    return new ResultModel { Success = false, Message = "Product not found" };
                }
                _dbContext.Categories.Remove(category);

                await _dbContext.SaveChangesAsync();

                return new ResultModel { Success = false, Message = "Category Succsesfuly deleted" };
            }
            catch(Exception ex)
            {
                return new ResultModel { Success = false, Message = ex.Message };
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            try
            {
                var categories = await _dbContext.Categories.ToListAsync();
                if (categories == null) return null;
                return categories;
            }
            catch(Exception ex)
            {
                return null;
            }   
        }

        public async Task<Category> GetByIdAsync(int productId)
        {
            try
            {
                var category = await _dbContext.Categories.FindAsync(productId);
                if (category == null) return null;
                return category;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<ResultModel> UpdateAsync(Category category)
        {
            try
            {
                var updatedCategory = await _dbContext.Categories.FindAsync(category.Id);
                if (updatedCategory == null) return new ResultModel { Success = false, Message = "Category not found" };

                category.Name = updatedCategory.Name;

                _dbContext.Categories.Update(category);
                await _dbContext.SaveChangesAsync();
                return new ResultModel { Success = true, Message = "Category Updated Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = ex.Message };
            }
        }
    }
}
