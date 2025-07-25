using DAL.DBContexts;
using DAL.IRepositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly eStoreDbContext _context;

        public ProductRepository(eStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>>? predicate = null)
        {
            if (predicate != null)
                return await _context.Products.Include(p => p.Category).Where(predicate).ToListAsync();

            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category)
                                          .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public IQueryable<Product> GetAllQueryable()
        {
            return _context.Products.Include(p => p.Category);
        }
    }
}
