using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;

namespace ECommerce.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<ProductDTO>> GetAllProductAsync(string? sort,int? categoryId);
        Task<bool> AddAsync(AddProductDTO ProductDTO);
        Task<bool> UpdateAsync(UpdateProductDTO dto);
        Task DeleteAsync(Product product);
    }
}
