using ConsoleApp2.Entity;
using ConsoleApp2.Interface;
using ConsoleApp2.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Services
{
    public class ManufacturerManager : IRepositary<Manufacturer>
    {
        private readonly EntityContext _dbContext;
        public ManufacturerManager(EntityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultModel> AddAsync(Manufacturer manufacturer)
        {
            try
            {
                await _dbContext.Manufacturers.AddAsync(manufacturer);

                await _dbContext.SaveChangesAsync();

                return new ResultModel { Success = true, Message = "Category Succsesfuly added" };
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = ex.Message };
            }
        }

        public async Task<ResultModel> DeleteAsync(int manufacturerId)
        {
            try
            {
                var manufacturer = await _dbContext.Manufacturers.FindAsync();
                if (manufacturer == null)
                {
                    return new ResultModel { Success = false, Message = "Product not found" };
                }
                _dbContext.Manufacturers.Remove(manufacturer);

                await _dbContext.SaveChangesAsync();

                return new ResultModel { Success = false, Message = "Category Succsesfuly deleted" };
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = ex.Message };
            }
        }

        public async Task<List<Manufacturer>> GetAllAsync()
        {
            try
            {
                var manufacturers = await _dbContext.Manufacturers.ToListAsync();
                if (manufacturers == null) return null;
                return manufacturers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Manufacturer> GetByIdAsync(int manufacturerId)
        {
            try
            {
                var manufacturer = await _dbContext.Manufacturers.FindAsync(manufacturerId);
                if (manufacturer == null) return null;
                return manufacturer;
            }
            catch
            {
                return null;
            }
        }

        public async Task<ResultModel> UpdateAsync(Manufacturer manufacturer)
        {
            try
            {
                var updatedManufacturer = await _dbContext.Manufacturers.FindAsync(manufacturer.Id);
                if (updatedManufacturer == null) return new ResultModel { Success = false, Message = "Category not found" };

                manufacturer.Name = updatedManufacturer.Name;

                _dbContext.Manufacturers.Update(manufacturer);
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
