using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories
{
    public interface ICateRepository
    {
        Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> predicate = null);
    }
}
