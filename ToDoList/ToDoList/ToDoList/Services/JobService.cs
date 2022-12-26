using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoList.Data.Models;
using ToDoList.Dtos.Jobs;
using ToDoList.Repository;

namespace ToDoList.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStateRepository _stateRepository;

        public JobService(IJobRepository jobRepository, IMapper mapper, ICategoryRepository categoryRepository, IStateRepository stateRepository)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _stateRepository = stateRepository;
        }

        public async Task<JobDto> AddAsync(CreateJobDto item)
        {
            var findCategory = await _categoryRepository.GetByIdAsync(item.CategoryId);

            if (findCategory == null)
            {
                throw new Exception($"Category not found {item.CategoryId}");
            }

            //var state = await _stateRepository.GetByIdAsync(item.StateId);
            //if (state == null)
            //{
            //    throw new Exception($"state not found {item.StateId}");
            //}
            var entity = _mapper.Map<CreateJobDto, Job>(item);
            await _jobRepository.AddAsync(entity);
            return _mapper.Map<Job, JobDto>(entity);
        }

        public async Task DeleteAsync<TKey>(TKey key)
        {
            var entity = await _jobRepository.GetByIdAsync(key);
            if (entity == null)
            {
                throw new Exception($"Job not found {key}");
            }
            await _jobRepository.DeleteAsync(entity);
        }

        public async Task<List<JobDto>> FilterAsync(FilterJobDto filter)
        {
            var filterEntity = await (await _jobRepository.GetQueryableAsync())
                .Where(x => x.CategoryId == filter.CategoryId && x.StateId == filter.StateId)
                .ToListAsync();
            // Map<TSource, TDestination>(TSource source);
            return _mapper.Map<List<Job>, List<JobDto>>(filterEntity);
        }

        public async Task<List<JobDto>> GetAllAsync()
        {
            var entity = await _jobRepository.GetAllAsync();
            return _mapper.Map<List<Job>, List<JobDto>>(entity);
        }

        public async Task<JobDto> GetByIdAsync<TKey>(TKey key)
        {
            var entity = await _jobRepository.GetByIdAsync(key);

            return _mapper.Map<Job, JobDto>(entity);
        }

        public async Task<JobDto> UpdateAsync(UpdateJobDto item)
        {
            var findCategory = await _categoryRepository.GetByIdAsync(item.CategoryId);

            if (findCategory == null)
            {
                throw new Exception($"Category not found {item.CategoryId}");
            }

            //var state = await _stateRepository.GetByIdAsync(item.StateId);

            //if (state == null)
            //{
            //    throw new Exception($"State not found {item.StateId}");
            //}

            var entity = await _jobRepository.GetByIdAsync(item.Id);
            if (entity == null)
            {
                throw new Exception($"Job not found {item.Id}");
            }

            var result = _mapper.Map<UpdateJobDto, Job>(item, entity);
            await _jobRepository.UpdateAsync(result);

            return _mapper.Map<Job, JobDto>(entity);
        }

        //public Task<JobDto> 

        //public async Task AddAsync(Job job)
        //{
        //    await _jobRepository.AddAsync(job);
        //}

        //public async Task<List<JobDto>> GetAllAsync()
        //{
        //    var jobs = await _jobRepository.GetAllAsync();
        //    return _mapper.Map<List<Job>, List<JobDto>>(jobs);

        //    //return await _jobRepository.GetAllAsync();
        //}

        //public async Task<Job> GetByIdAsync(int Id)
        //{
        //    return await _jobRepository.GetByIdAsync(Id);
        //}

        //public Task RemoveAsync(Job job)
        //{
        //    //await _jobRepository.RemoveAsync(job);
        //    return Task.CompletedTask;
        //}

        //public async Task UpdateAsync(Job job)
        //{
        //    await _jobRepository.UpdateAsync(job);
        //}
    }
}
