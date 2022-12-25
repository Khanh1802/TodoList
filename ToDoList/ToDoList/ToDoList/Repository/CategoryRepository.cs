using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Data;
using ToDoList.Data.Models;

namespace ToDoList.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ToDoListDbContext _context;

        public CategoryRepository(ToDoListDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Category category)
        {
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
