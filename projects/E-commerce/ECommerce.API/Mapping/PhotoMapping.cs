using AutoMapper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;

namespace ECommerce.API.Mapping
{
    public class PhotoMapping : Profile
    {
        public PhotoMapping()
        {
            CreateMap<Photo, PhotoDTO>().ReverseMap();
        }
    }
}
