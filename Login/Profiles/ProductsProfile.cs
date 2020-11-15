using AutoMapper;
using Login.Models;
using Login.Dtos;

namespace Login.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            // Source (database) -> Target (user)
            // GET
            CreateMap<Product, ProductGetDto>();
            // POST            
            CreateMap<ProductCreateUpdateDto, Product>();
        }
    }
}