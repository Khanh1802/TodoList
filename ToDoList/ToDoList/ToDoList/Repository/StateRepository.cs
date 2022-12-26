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

        public async Task<State> AddAsync(State item)
        {
            await _context.States.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(State item)
        {
            item.DeletetionTime = DateTime.Now;
            item.IsDeleted = true;
            await _context.SaveChangesAsync();

        }

        public async Task<List<State>> GetAllAsync()
        {
            return await _context.States
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<State> GetByIdAsync<TKey>(TKey key)
        {
            return await _context.States.FindAsync(key);

        }

        public Task<IQueryable<State>> GetQueryableAsync()
        {
            return Task.FromResult(_context.States.AsQueryable());
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<State> UpdateAsync(State item)
        {
            item.LastModificationTime = DateTime.Now;
            _context.States.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
