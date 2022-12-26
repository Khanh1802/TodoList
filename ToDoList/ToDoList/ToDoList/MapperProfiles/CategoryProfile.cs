using AutoMapper;
using ToDoList.Data.Models;
using ToDoList.Dtos.CategoryDto;

namespace ToDoList.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<FilterCategoryDto, Category>();
        }
    }
}
