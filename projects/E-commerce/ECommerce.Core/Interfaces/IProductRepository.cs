using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;
using ECommerce.Core.Helper;

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
