using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface IProductRepository
    {

        Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>>? predicate = null);
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task SaveAsync();

        IQueryable<Product> GetAllQueryable();
    }
}
