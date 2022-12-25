using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Data;
using ToDoList.Data.Models;

namespace ToDoList.Repository
{
    //public class JobRepository : IJobRepository
    //{
    //    private readonly ToDoListDbContext _context;

    //    public JobRepository(ToDoListDbContext context)
    //    {
    //        _context = context;
    //    }

    //    /// <summary>
    //    /// Vì giải quyết 2 method nên phải await async
    //    /// </summary>
    //    /// <param name="job"></param>
    //    /// <returns></returns>
    //    public async Task AddAsync(Job job)
    //    {
    //        await _context.Jobs.AddAsync(job);
    //        await _context.SaveChangesAsync();
    //    }

    //    /// <summary>
    //    /// Vì không giải quyết thêm method nào nữa nên không cần ghi them async
    //    /// </summary>
    //    /// <returns></returns>
    //    public Task<List<Job>> GetAllAsync()
    //    {
    //        return _context.Jobs.Where(x => x.IsDeleted != true).ToListAsync();
    //    }

    //    /// <summary>
    //    /// Trả về ValueTask nên cần phải async
    //    /// </summary>
    //    /// <param name="Id"></param>
    //    /// <returns></returns>
    //    public async Task<Job> GetByIdAsync(int id)
    //    {
    //        return await _context.Jobs.FindAsync(id);
    //    }

    //    public async Task RemoveAsync(Job job)
    //    {
    //        job.IsDeleted = true;
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task UpdateAsync(Job job)
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //}

    public class JobRepository : IJobRepository
    {
        private readonly ToDoListDbContext _context;

        public JobRepository(ToDoListDbContext context)
        {
            _context = context;
        }

        public async Task<Job> AddAsync(Job item)
        {
            await _context.Jobs.AddAsync(item);
            await SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(Job item)
        {
            item.DeletetionTime = DateTime.Now;
            item.IsDeleted = true;
            await UpdateAsync(item);
        }

        public Task<List<Job>> GetAllAsync()
        {
            return _context.Jobs
                .Where(x => !x.IsDeleted)
                .Include(x => x.Category)
                .Include(x => x.State)
                .ToListAsync();
        }

        public async Task<Job> GetByIdAsync<TKey>(TKey key)
        {
            return await _context.Jobs.FindAsync(key);
        }

        public Task<IQueryable<Job>> GetQueryableAsync()
        {
            // Vì AsQueryalbe không phải dạng Task nên phải dùng Task.FromResult 
            return Task.FromResult(_context.Jobs.AsQueryable());
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<Job> UpdateAsync(Job item)
        {
            item.LastModificationTime = DateTime.Now;
            _context.Jobs.Update(item);
            await SaveChangesAsync();

            return item;
        }
    }

}
