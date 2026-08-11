
using AutoMapper;
using ECommerce.API.Helper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

            if (ProductDTO.Photos is not null && ProductDTO.Photos.Count > 0)
            {
                var ImagePath = await _imageManagementService.AddImageAsync(ProductDTO.Photos, "products");
                var photos = ImagePath.Select(path => new Photo
                {
                    Name = path,
                    ProductId = product.Id
                });

                await _context.Photos.AddRangeAsync(photos);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateProductDTO dto)
        {
            if (dto is null)
                return false;

            var FindProduct = await _context.Products
                .Include(c => c.Category)
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (FindProduct is null)
                return false;

            _mapper.Map(dto, FindProduct);

            if (dto.Photos is not null && dto.Photos.Count > 0)
            {
                var FindPhotos = await _context.Photos.Where(p => p.ProductId == dto.Id).ToListAsync();
                foreach (var item in FindPhotos)
                {
                    await _imageManagementService.DeleteImageAsync(item.Name);
                }

                _context.Photos.RemoveRange(FindPhotos);

                var imagePath = await _imageManagementService.AddImageAsync(dto.Photos, "products");
                var photos = imagePath.Select(path => new Photo
                {
                    Name = path,
                    ProductId = dto.Id
                }).ToList();

                await _context.Photos.AddRangeAsync(photos);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task DeleteAsync(Product product)
        {
            var tracked = await _context.Products.Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == product.Id);

            foreach (var photo in tracked.Photos)
                await _imageManagementService.DeleteImageAsync(photo.Name);

            _context.Products.Remove(tracked);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductDTO>> GetAllProductAsync(ProductParams productParams)
        {
            var query = _context.Products
                .Include(c => c.Category)
                .Include(p => p.Photos)
                .AsNoTracking();
            if (productParams.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == productParams.CategoryId);
            }
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "PriceAsc":
                        query = query.OrderBy(p => p.NewPrice);
                        break;
                    case "PriceDESC":
                        query = query.OrderByDescending(p => p.NewPrice);
                        break;
                    default:
                        query = query.OrderBy(p => p.Name);
                        break;
                }
            }
            var pagedEntities = query.Paginate(productParams.Page,productParams.Size);
            var mappedData = _mapper.Map<List<ProductDTO>>(pagedEntities.Data);

            var result = _mapper.Map<IReadOnlyList<ProductDTO>>(pagedEntities.Data);

            return new PagedResult<ProductDTO>
            {
                Data = result,
                CurrentPage = pagedEntities.CurrentPage,
                PageSize = pagedEntities.PageSize,
                TotalItems = pagedEntities.TotalItems,
                TotalPages = pagedEntities.TotalPages
            };
        }

      
    }
}
