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
    }
} 