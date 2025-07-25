using AutoMapper;
using BLL.DTOs;
using BLL.IServices;
using DAL.IRepositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetActiveProductsAsync()
        {
            var products = await _repo.GetAllAsync(p => p.Status); // Lấy sản phẩm status = true

            // Load CategoryName cho từng Product (giả sử Category đã được include hoặc lazy load)
            return products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ImgUrl = p.ImgUrl,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.CategoryName ?? string.Empty
            }).ToList();
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDTO>(product);
        }

        public async Task AddProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repo.AddAsync(product);
            await _repo.SaveAsync();
        }

        public async Task UpdateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repo.UpdateAsync(product);
            await _repo.SaveAsync();
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product != null)
            {
                product.Status = false;
                await _repo.UpdateAsync(product);
                await _repo.SaveAsync();
            }
        }
        /// <summary>
        /// Lấy danh sách sản phẩm phân trang, có filter theo category nếu truyền vào.
        /// </summary>
        public async Task<PagedResultDTO<ProductDTO>> GetPagedProductsAsync(int page, int pageSize, int? categoryId = null)
        {
            var query = _repo.GetAllQueryable().Where(p => p.Status);
            if (categoryId.HasValue && categoryId.Value != 0)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }
            var totalItems = await query.CountAsync();
            if (totalItems == 0)
            {
                return new PagedResultDTO<ProductDTO>
                {
                    Items = new List<ProductDTO>(),
                    TotalItems = 0,
                    Page = 1,
                    PageSize = pageSize
                };
            }
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            if (page > totalPages) page = totalPages;
            if (page < 1) page = 1;
            var products = await query
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var productDTOs = products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ImgUrl = p.ImgUrl,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.CategoryName ?? string.Empty,
                Weight = p.Weight,
                UnitsInStock = p.UnitsInStock,
                Status = p.Status
            }).ToList();
            return new PagedResultDTO<ProductDTO>
            {
                Items = productDTOs,
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}
