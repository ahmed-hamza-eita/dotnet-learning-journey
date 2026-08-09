using ECommerce.Core.Entities.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Core.DTO
{
    public record PhotoDTO(int Id, string Name, int ProductId);

}
