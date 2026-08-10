using AutoMapper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;

namespace ECommerce.API.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.CategoryName
                , opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();


            CreateMap<AddProductDTO, Product>()
             .ForMember(p => p.Photos, opt => opt.Ignore());
        }
    }
}
