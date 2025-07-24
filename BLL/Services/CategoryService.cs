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

        public CategoryService(ICateRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Category>> GetActiveCategoriesAsync()
        {
            return await _repo.GetAllAsync(c => c.Status == true);
        }
    }
} 