using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PagedResultDTO<T>
    {
        public List<T> Items { get; set; } = new List<T>();   // Danh sách dữ liệu trả về
        public int TotalItems { get; set; }                   // Tổng số bản ghi trong CSDL
        public int Page { get; set; }                         // Trang hiện tại
        public int PageSize { get; set; }                     // Kích thước trang (số bản ghi/trang)

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize); 
    }
}
