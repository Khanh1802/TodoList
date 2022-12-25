using ToDoList.Data.Models;

namespace ToDoList.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task RemoveAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task UpdateAsync(Category category);

    }
}
