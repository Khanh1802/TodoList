using ToDoList.Data.Models;
using ToDoList.Dtos.Jobs;

namespace ToDoList.Services
{
    public interface IJobService : IGenericService<JobDto, CreateJobDto, UpdateJobDto, FilterJobDto>
    {
        //Task<List<JobDto>> GetAllAsync();
        //Task AddAsync(Job job);
        //Task UpdateAsync(Job job);
        //Task RemoveAsync(Job job);
        //Task<Job> GetByIdAsync(int Id);


    }
}
