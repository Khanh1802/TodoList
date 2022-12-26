using AutoMapper;
using ToDoList.Data.Models;
using ToDoList.Dtos.States;

namespace ToDoList.MapperProfiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDto>();
            CreateMap<CreateStateDto, State>();
            CreateMap<UpdateStateDto, State>();
            CreateMap<FilterStateDto,State>();
        }
    }
}
