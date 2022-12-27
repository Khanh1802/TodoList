using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            //C1:
            //var entity = _mapper.Map<CreateStateDto, State>(item);
            //C2:
            //var entity = _mapper.Map(item,new State());
            //C3:
            var entity = new State();
            _mapper.Map(item, entity);
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

        public async Task<List<StateDto>> FilterAsync(FilterStateDto filter)
        {
            //var filterState = await (await _stateRepository.GetQueryableAsync())
            //    .Where(x => x.Name.Contains(filter.Name))
            //    .ToListAsync();
            var filterState = await (await _stateRepository.GetQueryableAsync())
                .Where(x => EF.Functions.Like(x.Name,$"{filter.Name}%"))
                .ToListAsync();
                //.Where(obj => DbFunctions.Like(obj.Column, "%expression%"))
            //Map<TSource, TDestination>(TSource source);
            return _mapper.Map<List<State>, List<StateDto>>(filterState);                
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
