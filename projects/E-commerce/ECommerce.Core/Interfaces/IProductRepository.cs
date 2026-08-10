using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;

namespace ECommerce.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> AddAsync(AddProductDTO ProductDTO);
        Task<bool> UpdateAsync(UpdateProductDTO dto);
    }
}
