using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Category mapping
            //CreateMap<Category, CategoryDTO>().ReverseMap();

            //// Product mapping
            //CreateMap<Product, ProductDTO>()
            // .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : string.Empty))
            // .ReverseMap();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Product, ProductDTO>();


        }
    }
}
