using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoriesEntity = await _categoryRepository.GetCategoryById(id);
            return _mapper.Map<CategoryDTO>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetAllCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoriesEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(categoriesEntity);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoriesEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(categoriesEntity);
        }

        public async Task Remove(int? id)
        {
            var categoriesEntity = _categoryRepository.GetCategoryById(id).Result;
            await _categoryRepository.Remove(categoriesEntity);
        }
    }
}
