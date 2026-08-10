using Microsoft.AspNetCore.Http;

namespace ECommerce.Core.DTO
{
    public record ProductDTO(
        int Id,
        string Name,
        string Description,
        decimal NewPrice,
        decimal OldPrice,
        int CategoryId,
        string CategoryName,
        List<PhotoDTO> Photos
    );
    public record AddProductDTO()
    {
        public string Name { set; get; } = string.Empty;
        public string Description { set; get; } = string.Empty;
        public decimal NewPrice { set; get; }
        public decimal OldPrice { set; get; }
        public int CategoryId { set; get; }
        public IFormFileCollection Photos { get; set; }
    }
}
