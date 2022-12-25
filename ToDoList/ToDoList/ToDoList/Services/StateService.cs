using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoList.Data.Models;
using ToDoList.Dtos.States;
using ToDoList.Repository;

namespace ToDoList.Services
{
    public class StateService : IStateService
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }


        public async Task<StateDto> AddAsync(CreateStateDto item)
        {
            var entity = _mapper.Map<CreateStateDto,State>(item);
            await _stateRepository.AddAsync(entity);
            return _mapper.Map<State,StateDto>(entity);
            //var entity = _mapper.Map<CreateJobDto, Job>(item);
            //await _jobRepository.AddAsync(entity);
            //return _mapper.Map<Job, JobDto>(entity);
        }

        public async Task DeleteAsync<TKey>(TKey key)
        {
            var findState = await _stateRepository.GetByIdAsync(key);
            if(findState == null)
            {
                throw new Exception("Not found State");
            }
            await _stateRepository.DeleteAsync(findState);
        }

        public Task<List<StateDto>> FilterAsync(FilterStateDto filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StateDto>> GetAllAsync()
        {
            //return _mapper.Map<List<State, StateDto>>();
            //return await _stateRepository.GetAllAsync();
            List<State> listState = await _stateRepository.GetAllAsync();
            return _mapper.Map<List<State>,List<StateDto>>(listState);
        }

        public async Task<StateDto> GetByIdAsync<TKey>(TKey key)
        {
            var state = await _stateRepository.GetByIdAsync(key);
            return _mapper.Map<State,StateDto>(state);
        }

        public async Task<StateDto> UpdateAsync(UpdateStateDto item)
        {
            var entity = await _stateRepository.GetByIdAsync(item.Id);
            if(entity == null)
            {
                throw new Exception("Not found State");
            }
            _mapper.Map<UpdateStateDto,State>(item,entity);
            await _stateRepository.UpdateAsync(entity);
            return _mapper.Map<State,StateDto>(entity);
        }
    }
}
