using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetActiveCategoriesAsync();
        Task<CategoryDTO?> GetByIdAsync(int id);
        Task AddCategoryAsync(CategoryDTO categoryDto);
        Task UpdateCategoryAsync(CategoryDTO categoryDto);
        Task SoftDeleteCategoryAsync(int id);
    }
}
