using ConsoleApp2.Models;

namespace ConsoleApp2.Interface
{
    public interface IRepositary<T> where T : class
    {
        Task<ResultModel> AddAsync(T item);

        Task<ResultModel> DeleteAsync(int itemId);

        Task<ResultModel> UpdateAsync(T item);

        Task<T> GetByIdAsync(int itemId);

        Task<List<T>> GetAllAsync();
    }
}
