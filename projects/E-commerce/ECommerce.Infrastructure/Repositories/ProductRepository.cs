
using AutoMapper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Infrastructure.Data;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly IImageManagementService _imageManagementService;
        public ProductRepository(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService) : base(context)
        {
            _mapper = mapper;
            _imageManagementService = imageManagementService;
        }

        public async Task<bool> AddAsync(AddProductDTO ProductDTO)
        {
            if (ProductDTO is null)
                return false;

            var product = _mapper.Map<Product>(ProductDTO);
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            var ImagePath = await _imageManagementService.AddImageAsync(ProductDTO.Photos, "products");
            var photos = ImagePath.Select(path => new Photo
            {
                Name = path,
                ProductId = product.Id
            });

            await _context.Photos.AddRangeAsync(photos);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
