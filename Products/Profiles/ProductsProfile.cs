using AutoMapper;
using Products.Models;
using Products.Dtos;

namespace Products.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {         
            CreateMap<PostProductDto, Product>();
        }
    }
}