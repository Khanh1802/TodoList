using ToDoList.Data.Models;
using ToDoList.Repository;

namespace ToDoList.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task AddAsync(State state)
        {
            await _stateRepository.AddAsync(state);
        }

        public async Task<List<State>> GetAllAsync()
        {
            return await _stateRepository.GetAllAsync();
        }

        public async Task<State> GetByIdAsync(int id)
        {
            return await _stateRepository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(State state)
        {
            await _stateRepository.RemoveAsync(state);
        }

        public async Task UpdateAsync(State state)
        {
            await _stateRepository.UpdateAsync(state);
        }
    }
}
