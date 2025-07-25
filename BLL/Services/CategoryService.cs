using AutoMapper;
using BLL.DTOs;
using BLL.IServices;
using DAL.DBContexts;
using DAL.IRepositories;
using DAL.Models;
using DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICateRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICateRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetActiveCategoriesAsync()
        {
            var categories = await _repo.GetAllAsync(c => c.Status == true);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetByIdAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            return category == null ? null : _mapper.Map<CategoryDTO>(category);
        }

        public async Task AddCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _repo.AddAsync(category);
            await _repo.SaveAsync();
        }

        public async Task UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _repo.UpdateAsync(category);
            await _repo.SaveAsync();
        }

        public async Task SoftDeleteCategoryAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category != null)
            {
                category.Status = false;
                await _repo.UpdateAsync(category);
                await _repo.SaveAsync();
            }
        }
    }
} 