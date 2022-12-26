using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Models;
using ToDoList.Dtos.CategoryDto;
using ToDoList.Repository;

namespace ToDoList.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddAsync(CreateCategoryDto item)
        {
            var entity = _mapper.Map<CreateCategoryDto, Category>(item);
            await _categoryRepository.AddAsync(entity);
            return _mapper.Map<Category, CategoryDto>(entity);
        }

        public async Task DeleteAsync<TKey>(TKey key)
        {
            var category = await _categoryRepository.GetByIdAsync(key);
            if (category is null)
            {
                throw new Exception("Not found Category");
            }
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<List<CategoryDto>> FilterAsync(FilterCategoryDto filter)
        {
            var filterCategory = await (await _categoryRepository.GetQueryableAsync())
                .Where(x => x.Name.Contains(filter.Name))
                .ToListAsync();
            return _mapper.Map<List<Category>, List<CategoryDto>>(filterCategory);
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var listCategory = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<Category>, List<CategoryDto>>(listCategory);
        }

        public async Task<CategoryDto> GetByIdAsync<TKey>(TKey key)
        {
            var entity = await _categoryRepository.GetByIdAsync(key);
            if (entity is null)
            {
                throw new Exception("Not found Category");
            }
            return _mapper.Map<Category, CategoryDto>(entity);
        }

        public async Task<CategoryDto> UpdateAsync(UpdateCategoryDto item)
        {
            var entity = await _categoryRepository.GetByIdAsync(item.Id);
            if (entity is null)
            {
                throw new Exception("Not found Category");
            }
            var category = _mapper.Map<UpdateCategoryDto, Category>(item, entity);
            await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<Category, CategoryDto>(category);
        }

        //public async Task AddAsync(Category category)
        //{
        //    //await _categoryRepository.AddAsync(category);
        //}

        //public async Task RemoveAsync(Category category)
        //{
        //    //await _categoryRepository.RemoveAsync(category);
        //}

        //public async Task<List<Category>> GetAllAsync()
        //{
        //    //return await _categoryRepository.GetAllAsync();
        //}

        //public async Task<Category> GetByIdAsync(int id)
        //{
        //    //return await _categoryRepository.GetByIdAsync(id);
        //}

        //public async Task UpdateAsync(Category category)
        //{
        //    //await _categoryRepository.UpdateAsync(category);
        //}
    }
}
