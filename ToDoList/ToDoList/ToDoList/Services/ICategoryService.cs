using ToDoList.Data.Models;
using ToDoList.Dtos.CategoryDto;
using ToDoList.Repository;

namespace ToDoList.Services
{
    public interface ICategoryService :  IGenericService<CategoryDto,CreateCategoryDto,UpdateCategoryDto,FilterCategoryDto>
    {
       
    }
}
