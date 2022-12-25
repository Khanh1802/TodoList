using ToDoList.Data.Models;

namespace ToDoList.Repository
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllAsync();
        Task AddAsync(State state);
        Task RemoveAsync(State state);
        Task<State> GetByIdAsync(int id);
        Task UpdateAsync(State state);
    }
}
