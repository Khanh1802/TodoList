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

        public async Task<Category> AddAsync(Category item)
        {
            await _context.Categories.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Category item)
        {
            item.IsDeleted = true;
            item.DeletetionTime = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<Category> GetByIdAsync<TKey>(TKey key)
        {
            return await _context.Categories.FindAsync(key);
        }

        public async Task<IQueryable<Category>> GetQueryableAsync()
        {
            return await Task.FromResult(_context.Categories.Where(x => !x.IsDeleted).AsQueryable());
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<Category> UpdateAsync(Category item)
        {
            item.LastModificationTime = DateTime.Now;
            _context.Categories.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        //public async Task AddAsync(Category category)
        //{
        //    await _context.AddAsync(category);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task RemoveAsync(Category category)
        //{
        //    category.IsDeleted = true;
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<List<Category>> GetAllAsync()
        //{
        //    return await _context.Categories.ToListAsync();
        //}

        //public async Task<Category> GetByIdAsync(int id)
        //{
        //    return await _context.Categories.FindAsync(id);
        //}

        //public async Task UpdateAsync(Category category)
        //{
        //    _context.Update(category);
        //    await _context.SaveChangesAsync();
        //}
    }
}
