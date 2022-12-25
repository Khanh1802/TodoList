namespace ToDoList.Services
{
    public interface IGenericService<TEntityDto, TCreateEntity, TUpdateEntityDto,TFilterEntityDto> where TEntityDto : class
    {
        Task<List<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetByIdAsync<TKey>(TKey key);
        Task<TEntityDto> AddAsync(TCreateEntity item);
        Task<TEntityDto> UpdateAsync(TUpdateEntityDto item);
        Task DeleteAsync<TKey>(TKey key);
        Task<List<TEntityDto>> FilterAsync(TFilterEntityDto filter);
    }
}
