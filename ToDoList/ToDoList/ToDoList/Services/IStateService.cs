using ToDoList.Data.Models;
using ToDoList.Dtos.States;

namespace ToDoList.Services
{
    public interface IStateService : IGenericService<StateDto, CreateStateDto, UpdateStateDto, FilterStateDto>
    {
        
    }
}
