using DAL.DBContexts;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : ICateRepository
    {
        private readonly eStoreDbContext _context;
        public CategoryRepository(eStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> predicate = null)
        {
            if (predicate != null)
                return await _context.Categories.Where(predicate).ToListAsync();

            return await _context.Categories.ToListAsync();
        }
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
} 