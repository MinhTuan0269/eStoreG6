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
        Task<IEnumerable<Category>> GetActiveCategoriesAsync();
    }
}
