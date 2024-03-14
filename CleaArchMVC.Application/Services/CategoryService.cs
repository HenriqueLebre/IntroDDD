using AutoMapper;
using CleaArchMVC.Application.DTOs;
using CleaArchMVC.Application.Interfaces;
using CleaArchMVC.Domain.Entities;
using CleaArchMVC.Domain.Interfaces;

namespace CleaArchMVC.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Add(CategoryDTO categoryDto)
        {
            var categorieEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Create(categorieEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoryById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Remove(int? id)
        {
            var categorieEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(categorieEntity);
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var categorieEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(categorieEntity);
        }
    }
}
