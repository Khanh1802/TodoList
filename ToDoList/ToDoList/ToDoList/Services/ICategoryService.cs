using ToDoList.Data.Models;

namespace ToDoList.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task RemoveAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task UpdateAsync(Category category);
    }
}
