using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Data;
using ToDoList.Data.Models;

namespace ToDoList.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly ToDoListDbContext _context;

        public StateRepository(ToDoListDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(State state)
        {
            await _context.AddAsync(state);
            await _context.SaveChangesAsync();
        }

        public async Task<List<State>> GetAllAsync()
        {
            return await _context.States.ToListAsync();
        }

        public async Task<State> GetByIdAsync(int id)
        {
            return await _context.States.FindAsync(id);
        }

        public async Task RemoveAsync(State state)
        {
            state.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(State state)
        {            
            await _context.SaveChangesAsync();
        }
    }
}
