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
            // Khai báo khi cần dùng để map
            CreateMap<FilterStateDto,State>();
        }
    }
}
