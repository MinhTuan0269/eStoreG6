using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
namespace BLL.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetActiveProductsAsync();
        Task<ProductDTO?> GetByIdAsync(int id);
        Task AddProductAsync(ProductDTO product);
        Task UpdateProductAsync(ProductDTO product);
        Task SoftDeleteProductAsync(int id);
        Task<PagedResultDTO<ProductDTO>> GetPagedProductsAsync(int page, int pageSize, int? categoryId = null);
  
    }
}
