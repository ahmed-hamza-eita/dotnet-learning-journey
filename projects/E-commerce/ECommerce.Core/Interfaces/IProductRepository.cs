using ECommerce.API.Helper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;

namespace ECommerce.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PagedResult<ProductDTO>> GetAllProductAsync(ProductParams productParams);
        Task<bool> AddAsync(AddProductDTO ProductDTO);
        Task<bool> UpdateAsync(UpdateProductDTO dto);
        Task DeleteAsync(Product product);
    }
}
