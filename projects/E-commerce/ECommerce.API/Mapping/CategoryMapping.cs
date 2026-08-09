using AutoMapper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;

namespace ECommerce.API.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
