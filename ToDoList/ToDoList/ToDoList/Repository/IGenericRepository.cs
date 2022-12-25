

namespace ToDoList.Repository
{
    //T phai la class nếu không where T : class thì sẽ hiểu là lấy tất cả
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> AddAsync(TEntity item);

        Task<TEntity> UpdateAsync(TEntity item);

        Task SaveChangesAsync();

        Task<IQueryable<TEntity>> GetQueryableAsync();

        Task DeleteAsync(TEntity item);

        // Tkey Tượng trưng cho kiểu dữ liệu
        Task<TEntity> GetByIdAsync<TKey>(TKey key);
    }
}
